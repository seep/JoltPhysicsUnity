using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

[Generator]
internal class JoltSourceGenerator : ISourceGenerator
{
    private static readonly JoltSourceGeneratorLog Log = new ();
    
    public void Initialize(GeneratorInitializationContext ctx)
    {
        ctx.RegisterForSyntaxNotifications(() => new JoltSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext ctx)
    {
        if (ctx.SyntaxReceiver is not JoltSyntaxReceiver recv) return;
        
        var bindings = IngestNativeBindings(recv);
        var wrappers = CreateNativeTypeWrapperList(recv, ctx);

        foreach (var binding in bindings.BindingsByNativeType)
        {
            Log.Debug($"Found bindings for {binding.Key}");
        }
        
        foreach (var wrapper in wrappers)
        {
            try
            {
                Log.Debug($"Generating {wrapper.TypeName}");
                
                var filename = $"{wrapper.TypeName}.g.cs";
                var filetext = GenerateNativeTypeWrapper(wrapper, bindings);
        
                ctx.AddSource(filename, filetext);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception while generating {wrapper.TypeName}:");
                Log.Error($"{ex}");
            }
        }
        
        Log.Flush();
    }

    /// <summary>
    /// Construct an optimized map of native extern functions from the syntax receiver pass.
    /// </summary>
    private static JoltNativeBindings IngestNativeBindings(JoltSyntaxReceiver recv)
    {
        var bindings = new JoltNativeBindings();

        foreach (var decl in recv.Bindings)
        {
            var parts = decl.Identifier.ValueText.Split('_');

            if (parts.Length < 3)
            {
                continue; // we are only interested in JPH_SomeType_Method bindings
            }

            var details = new JoltNativeBindingDetails($"{parts[0]}_{parts[1]}", decl);

            if (bindings.BindingsByNativeType.TryGetValue(details.NativeTypeName, out var value))
            {
                value.Add(details);
            }
            else
            {
                bindings.BindingsByNativeType.Add(details.NativeTypeName, [details]);
            }
        }

        return bindings;
    }

    /// <summary>
    /// Construct a list of native type wrapper metadata from the syntax receiver pass.
    /// </summary>
    private static List<JoltNativeTypeWrapper> CreateNativeTypeWrapperList(JoltSyntaxReceiver recv, GeneratorExecutionContext ctx)
    {
        var result = new List<JoltNativeTypeWrapper>();

        foreach (var decl in recv.Wrappers)
        {
            result.Add(CreateNativeTypeWrapper(ctx, decl));
        }

        return result;
    }

    private static JoltNativeTypeWrapper CreateNativeTypeWrapper(GeneratorExecutionContext ctx, StructDeclarationSyntax decl)
    {
        var symbol = ctx.Compilation.GetSemanticModel(decl.SyntaxTree).GetDeclaredSymbol(decl);
        var result = new JoltNativeTypeWrapper(decl.Identifier.ValueText);

        Debug.Assert(symbol != null);

        foreach (var attr in symbol.GetAttributes())
        {
            if (IsAttributeType(ctx, attr, "Jolt.GenerateBindingsAttribute"))
            {
                foreach (var type in attr.ConstructorArguments[0].Values)
                {
                    if (type.Value != null) result.NativeTypePrefixes.Add(type.Value.ToString());
                }
            }
        }

        foreach (var member in symbol.GetMembers())
        {
            if (member is IMethodSymbol { DeclaredAccessibility: Accessibility.Public } method)
            {
                // elide generated bindings that would share a name with a declared member
                result.ExcludedBindings.Add($"{result.NativeTypeName}_{method.Name}");
            }
        }

        return result;
    }

    private static bool IsAttributeType(GeneratorExecutionContext ctx, AttributeData attr, string type)
    {
        return ctx.Compilation.GetTypeByMetadataName(type)?.Equals(attr.AttributeClass, SymbolEqualityComparer.Default) ?? false;
    }

    private static string GenerateNativeTypeWrapper(JoltNativeTypeWrapper target, JoltNativeBindings bindings)
    {
        var writer = new IndentedTextWriter(new StringWriter());

        writer.WriteLine("using System;");
        writer.WriteLine("using Jolt;");
        writer.WriteLine("using Unity.Collections;");
        writer.WriteLine("using Unity.Mathematics;");
        writer.WriteLine();

        StartBlock(writer, "namespace Jolt");
        StartBlock(writer, $"public partial struct {target.TypeName} : IEquatable<{target.TypeName}>");

        GenerateEquatableInterface(writer, target);

        foreach (var prefix in target.NativeTypePrefixes)
        {
            GenerateBindingsWithPrefix(writer, target, bindings, prefix);
        }

        CloseBlock(writer);
        CloseBlock(writer);

        Debug.Assert(writer.Indent == 0);

        return writer.InnerWriter.ToString();
    }

    private static void GenerateEquatableInterface(IndentedTextWriter writer, JoltNativeTypeWrapper target)
    {
        WritePaddedLine(writer, "#region IEquatable");

        WritePaddedLine(writer, $"public bool Equals({target.TypeName} other) => Handle.Equals(other.Handle);");

        WritePaddedLine(writer, $"public override bool Equals(object obj) => obj is {target.TypeName} other && Equals(other);");

        WritePaddedLine(writer, $"public override int GetHashCode() => Handle.GetHashCode();");

        WritePaddedLine(writer, $"public static bool operator ==({target.TypeName} lhs, {target.TypeName} rhs) => lhs.Equals(rhs);");

        WritePaddedLine(writer, $"public static bool operator !=({target.TypeName} lhs, {target.TypeName} rhs) => !lhs.Equals(rhs);");

        WritePaddedLine(writer, "#endregion");
    }

    private static void GenerateBindingsWithPrefix(IndentedTextWriter writer, JoltNativeTypeWrapper target, JoltNativeBindings bindings, string prefix)
    {
        if (bindings.BindingsByNativeType.TryGetValue(prefix, out var bindingsWithPrefix))
        {
            WritePaddedLine(writer, $"#region {prefix}");
            
            foreach (var binding in bindingsWithPrefix)
            {
                GenerateBindings(writer, target, binding);
            }
            
            WritePaddedLine(writer, "#endregion");
        }
    }

    private static void GenerateBindings(IndentedTextWriter writer, JoltNativeTypeWrapper target, JoltNativeBindingDetails b)
    {
        var bindingName = b.BindingDeclaration.Identifier.ValueText;
        var wrapperName = bindingName.Substring(b.NativeTypeName.Length + 1); // JPH_SomeType_SomeMethodName -> SomeMethodName

        if (target.ExcludedBindings.Contains(bindingName))
        {
            return; // target has explicitly excluded this binding
        }

        if (b.BindingDeclaration.ParameterList.Parameters.Count == 0)
        {
            return; // TODO handle generating Create methods
        }

        // The wrapper struct methods generally fall into the same format:
        // 
        //     public void SetFriction ( float friction ) => Bindings.JPH_Body_GetFriction ( Handle, friction );
        //                 ^^^^^^^^^^^   ^^^^^^^^^^^^^^               ^^^^^^^^^^^^^^^^^^^^   ^^^^^^^^^^^^^^^^
        //                 wrapperName   wrapperParams                bindingName            bindingParams
        //
        // The following code generates the wrapper params and binding params simultaneously because they are
        // fairly interconnected.
        
        var bindingParams = new List<string>();
        var wrapperParams = new List<string>();

        // Add the handle parameter to the binding param list only.

        {
            
            var firstParamDecl = b.BindingDeclaration.ParameterList.Parameters[0];
            var firstParamType = firstParamDecl.Type!.ToString();
            
            if (firstParamType.StartsWith("NativeHandle") == false)
            {
                return; // TODO this is the Create category, or generally anything that is not a method binding 
            }
        
            string handleParam;
            
            var handleParamNativeTypeName = ExtractGenericTypeParameter(firstParamType);

            // Reinterpret the handle if the native type name is different. For example, the SphereShape wrapper
            // generates bindings for JPH_Shape, JPH_ConvexShape, and JPH_SphereShape because the native class
            // is a subclass of those two classes. Because the wrapper types are structs, API inheritance is
            // not an option. Instead we generate methods for the whole class hierarchy directly on the SphereShape
            // wrapper and internally reinterpret the handle into the native base class types.

            if (handleParamNativeTypeName != target.NativeTypeName)
            {
                handleParam = $"Handle.Reinterpret<{handleParamNativeTypeName}>()";
            }
            else
            {
                handleParam = "Handle";
            }

            if (firstParamDecl.Modifiers.Any(SyntaxKind.RefKeyword))
            {
                handleParam = $"ref {handleParam}"; // destroy bindings take handle by ref
            }
            
            bindingParams.Add(handleParam);
        }
        
        // Add the other parameters to both the binding and wrapper param list.

        foreach (var p in b.BindingDeclaration.ParameterList.Parameters.RemoveAt(0))
        {
            var bindingParamType = p.Type!.ToString();
            var bindingParamName = p.Identifier.ValueText;

            string bindingParam;
            string wrapperParam;

            if (bindingParamType.StartsWith("NativeHandle"))
            {
                // When the param is a NativeHandle, extract the generic type parameter and convert that into a wrapper
                // type name. For example, when the binding takes a NativeHandle<JPH_SphereShape> param the wrapper
                // method takes a SphereShape param and internally passes along its handle.
                
                var wrapperParamType = ExtractGenericTypeParameter(bindingParamType).Substring("JPH_".Length);
                var wrapperParamName = bindingParamName;

                bindingParam = $"{bindingParamName}.Handle"; 
                wrapperParam = $"{wrapperParamType} {wrapperParamName}";
            }
            else
            {
                // When the param is any other type, just reuse the binding param type and name with any modifiers.
                
                bindingParam = bindingParamName;
                wrapperParam = $"{bindingParamType} {bindingParamName}";
                
                if (p.Modifiers.Any(SyntaxKind.OutKeyword))
                {
                    bindingParam = $"out {bindingParam}";
                    wrapperParam = $"out {wrapperParam}";
                }
                
                if (p.Modifiers.Any(SyntaxKind.RefKeyword))
                {
                    bindingParam = $"ref {bindingParam}";
                    wrapperParam = $"ref {wrapperParam}";
                }
            }
            
            bindingParams.Add(bindingParam);
            wrapperParams.Add(wrapperParam);
        }

        var bindingParamsString = string.Join(", ", bindingParams);
        var wrapperParamsString = string.Join(", ", wrapperParams);

        var wrapperBody = $"Bindings.{bindingName}({bindingParamsString})";
        
        var bindingReturn = b.BindingDeclaration.ReturnType.ToString();
        var wrapperReturn = bindingReturn;

        if (wrapperName == "GetType")
        {
            wrapperName = "GetShapeType"; // JPH_Shape_GetType hides native GetType method
        }

        if (bindingReturn.StartsWith("NativeHandle"))
        {
            // If the binding returns a NativeHandle, instead construct and return the corresponding wrapper type.
            
            wrapperReturn = ExtractGenericTypeParameter(bindingReturn).Substring("JPH_".Length);
            wrapperBody = $"new {wrapperReturn} {{ Handle = {wrapperBody} }}";
        }
        
        WritePaddedLine(writer, $"public {wrapperReturn} {wrapperName}({wrapperParamsString}) => {wrapperBody};");
    }

    /// <summary>
    /// Returns the type parameter of a generic type.
    /// </summary>
    private static string ExtractGenericTypeParameter(string type)
    {
        var lbracket = type.IndexOf('<');
        var rbracket = type.IndexOf('>');
        return type.Substring(lbracket + 1, rbracket - lbracket - 1);
    }

    private static void StartBlock(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.WriteLine("{");

        writer.Indent++;
    }

    private static void CloseBlock(IndentedTextWriter writer)
    {
        writer.Indent--;

        writer.WriteLine("}");
    }

    private static void WritePaddedLine(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.WriteLine();
    }
}

/// <summary>
/// An optimized lookup of native extern functions.
/// </summary>
internal class JoltNativeBindings
{
    public readonly Dictionary<string, List<JoltNativeBindingDetails>> BindingsByNativeType = new ();
}

/// <summary>
/// Metadata about an individual native extern function we will proxy.
/// </summary>
internal class JoltNativeBindingDetails(string type, MethodDeclarationSyntax decl)
{
    public readonly string NativeTypeName = type;

    public readonly MethodDeclarationSyntax BindingDeclaration = decl;
}

/// <summary>
/// Metadata about a native type wrapper we will generate.
/// </summary>
internal class JoltNativeTypeWrapper(string type)
{
    public readonly string TypeName = type;

    public string NativeTypeName => $"JPH_{TypeName}";

    public readonly HashSet<string> NativeTypePrefixes = [];

    public readonly HashSet<string> ExcludedBindings = [];
}
