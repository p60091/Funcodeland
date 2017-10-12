using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CompCSharpDLL;

namespace CompareUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string com_in = null;
        private string ref_in = null;
        private string ori_in = null;
        private CSharpParser com_csp = null;
        private CSharpParser ref_csp = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool startup_error = false;

            TextCompareWindow wnd = new TextCompareWindow();
        
            for (int i = 0; i < e.Args.Length; i++)
            {
                if (e.Args[i] == "/c" || e.Args[i] == "/r")
                {
                    if (i + 1 < e.Args.Length)
                    {
                        if (e.Args[i] == "/c") com_in = e.Args[i + 1];
                        else if (e.Args[i] == "/r") ref_in = e.Args[i + 1];
                        i++;
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Argument " + e.Args[i] + " expects a parameter.");
                        startup_error = true;
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Unrecognized Argurment " + e.Args[i] + ".");
                    startup_error = true;
                    break;
                }
            }

            if (!startup_error)
            {
                try { 
                    if (com_in != null) com_in = System.IO.File.ReadAllText(com_in);
                    if (ref_in != null) ref_in = System.IO.File.ReadAllText(ref_in);

                    if (com_in != null) com_csp = new CSharpParser(com_in);
                    if (ref_in != null) ref_csp = new CSharpParser(ref_in);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                } 
            }

            wnd.SetText(ref_in, com_in);
            wnd.Show();
        }
    }
}
