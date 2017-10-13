using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.ObjectModel;

namespace CompCSharpDLL
{
    public class CSharpParser
    {
        private TreeViewNode root = null;
        private SyntaxTree tree = null;

        public CSharpParser(string text) {
            tree = CSharpSyntaxTree.ParseText(text);
        }

        public TreeViewNode Root()
        {
            if (root != null) return root;
            root = new TreeViewNode ((CompilationUnitSyntax)tree.GetRoot());
            return root;
        }
    }

    public class TreeViewNode
    {
        public TreeViewNode(SyntaxNode node, int depth = 0)
        {
            this.node = node;
            this.Items = new ObservableCollection<TreeViewNode>();

            // Preprocessor stuff
            //foreach( SyntaxTrivia trivia in node.GetLeadingTrivia() )
            //{
            //    this.Items.Add(new TreeViewNode(trivia, this.depth + 1));
            //}
            

            if (!node.IsKind(SyntaxKind.QualifiedName) &&
                //!node.IsKind(SyntaxKind.UsingDirective) &&
                !node.IsKind(SyntaxKind.ExternAliasDirective))
            {
                foreach (SyntaxNode member in node.ChildNodes())
                {
                    this.Items.Add(new TreeViewNode(member, this.depth + 1));
                }
            }
        }
        public TreeViewNode(SyntaxTrivia trivia, int depth = 0)
        {
            this.trivia = trivia; 
        }

        private int depth = 0;
        private SyntaxNode node = null;
        private SyntaxTrivia trivia;
        private string typeColor = null;
        private string textColor = null;

        public ObservableCollection<TreeViewNode> Items { get; set; }

        public string TypeString
        {
            get
            {
                if (node == null)
                    return "Trivia";
                return node.Kind().ToString();
            }
        }

        public string TypeColor
        {
            get
            {
                if (typeColor != null) return typeColor;
                return "Blue";
            }
        }

        public string TextColor
        {
            get
            {
                if (textColor != null) return textColor;
                return "Black";
            }
        }

        public string TextString {

            get
            {
                if (node == null)
                    return trivia.ToString();

                if (node.IsKind(SyntaxKind.AttributeTargetSpecifier))
                {
                    return ((AttributeTargetSpecifierSyntax)node).Identifier.ToString();
                }

                //else if (node.IsKind(SyntaxKind.Attribute))
                //{
                //    return ((AttributeSyntax)node).Name.ToString();
                //}  


                //else if (node.IsKind(SyntaxKind.UsingDirective))
                //{
                //    UsingDirectiveSyntax typenode = (UsingDirectiveSyntax)node;
                //    string retval = "";
                //    NameEqualsSyntax neNode = (NameEqualsSyntax)typenode.ChildNodes().Where(member => member.IsKind(SyntaxKind.NameEquals)).FirstOrDefault();
                //    if (neNode != null) retval += neNode.Name.ToString() + " = ";   // usingAliasDirective
                //    retval += typenode.StaticKeyword.Text;                          // usingStaticDirective
                //    return retval + typenode.Name.ToString();                       // FQN
                //}

                else if (node.IsKind(SyntaxKind.ExternAliasDirective))
                {
                    return ((ExternAliasDirectiveSyntax)node).Identifier.ToString();
                }


                else if (node.IsKind(SyntaxKind.QualifiedName) ||
                    node.IsKind(SyntaxKind.IdentifierName) ||
                    node.IsKind(SyntaxKind.VariableDeclarator) )
                {
                    return node.ToString();
                }

                else if (node.IsKind(SyntaxKind.StringLiteralExpression))
                {
                    string retval = ""; 
                    foreach (string line in node.ToString().Split('\n')) { retval += line + "\\n"; }
                    return retval.Substring(0,retval.Length-2);

                }

                return "";

                /* (node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.CompilationUnit) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.NamespaceDeclaration) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.ClassDeclaration) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.MethodDeclaration) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.Block) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.ForStatement) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.IfStatement) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.SwitchStatement) ||
                    node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.WhileStatement))*/
            }
        }


    }
}
