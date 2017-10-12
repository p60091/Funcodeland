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

namespace CompareUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TextCompareWindow : Window
    {
        public TextCompareWindow()
        {
            InitializeComponent();
            
        }

        public void SetText( string left, string right )
        {
            this.tbLeft.Text = left;
            this.tbRight.Text = right;
        }
    }
}
