using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

internal class JoltSyntaxReceiver : ISyntaxReceiver
{
    public readonly List<StructDeclarationSyntax> Targets = new ();

    public readonly List<MethodDeclarationSyntax> Bindings = new ();

    public void OnVisitSyntaxNode(SyntaxNode node)
    {
        if (node is MethodDeclarationSyntax mds && mds.Parent is ClassDeclarationSyntax { Identifier.ValueText: "SafeBindings" }) // TODO check namespace
        {
            Bindings.Add(mds);
        }

        if (node is StructDeclarationSyntax sds)
        {
            if (sds.Modifiers.Any(SyntaxKind.PartialKeyword) == false)
            {
                return; // skip non-partial
            }

            if (IncludesAttributeNamed(sds.AttributeLists, "GenerateHandle")) // TODO check namespace
            {
                Targets.Add(sds);
            }
        }
    }

    /// <summary>
    /// Returns true if the nested list of attributes contains any attribute with the provided name.
    /// </summary>
    private static bool IncludesAttributeNamed(SyntaxList<AttributeListSyntax> list, string name)
    {
        foreach (var l in list)
        {
            foreach (var a in l.Attributes)
            {
                if (a.Name.ToString() == name) return true;
            }
        }

        return false;
    }
}
