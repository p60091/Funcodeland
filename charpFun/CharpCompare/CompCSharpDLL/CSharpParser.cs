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

            //var firstMember = root.Members[0];
            //var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
            //var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
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
        public TreeViewNode(SyntaxNode node, int depth=0)
        {
            this.node = node;
            this.Items = new ObservableCollection<TreeViewNode>();
            if (!node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.QualifiedName))
                foreach ( SyntaxNode member in node.ChildNodes())
                {
                    this.Items.Add(new TreeViewNode(member, this.depth+1));
                }
        }
        private int depth = 0;
        private SyntaxNode node;
        public SyntaxNode Node
        {
            get { return node; }
        }

        public string Label {
            get {
                if (node.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.CompilationUnit))
                    return node.Kind().ToString();
                else return node.ToString();
            }
        }

        public ObservableCollection<TreeViewNode> Items { get; set; }
    }
}
