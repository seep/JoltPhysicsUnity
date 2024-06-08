using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

internal class JoltSyntaxReceiver : ISyntaxReceiver
{
    /// <summary>
    /// The list of struct declarations that wrap native types.
    /// </summary>
    public readonly List<StructDeclarationSyntax> Wrappers = new ();

    /// <summary>
    /// The list of method declarations that proxy extern methods.
    /// </summary>
    public readonly List<MethodDeclarationSyntax> Bindings = new ();

    public void OnVisitSyntaxNode(SyntaxNode node)
    {
        switch (node)
        {
            case MethodDeclarationSyntax mds:
                OnVisitMethodDeclaration(mds);
                break;
            case StructDeclarationSyntax sds:
                OnVisitStructDeclaration(sds);
                break;
        }
    }

    private void OnVisitMethodDeclaration(MethodDeclarationSyntax mds)
    {
        if (mds is { Parent: ClassDeclarationSyntax { Identifier.ValueText: "Bindings" } })
        {
            Bindings.Add(mds);
        }
    }

    private void OnVisitStructDeclaration(StructDeclarationSyntax sds)
    {
        if (sds.Modifiers.Any(SyntaxKind.PartialKeyword) == false)
        {
            return; // skip non-partial
        }

        if (IncludesAttributeNamed(sds.AttributeLists, "GenerateHandle"))
        {
            Wrappers.Add(sds);
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
