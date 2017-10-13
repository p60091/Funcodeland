using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompCSharpDLL;


namespace CompareUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class TreeCompareWindow : Window
    {
        public TreeCompareWindow()
        {
            InitializeComponent();
           
        }

        public void SetTree(CSharpParser left, CSharpParser right)
        {
            this.tvLeft.Items.Add(left.Root());
            this.tvRight.Items.Add(right.Root());
        }
    }
}
