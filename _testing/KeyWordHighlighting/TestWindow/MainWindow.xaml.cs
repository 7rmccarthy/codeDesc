using System;
using System.Windows;
using System.IO;

namespace TestWindow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //  Open file dialog window button handler
        private void insert_button_Click(object sender, RoutedEventArgs e)
        {
            //  Create a new openfiledialog
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            //  Filter for *.cs files only
            fileDialog.Filter = "c# files|*.cs";

            //  Empty try-catch so the program does not crash upon unwanted file dialog actions
            try
            {
                //  If the dialog has been opened successfully
                if (fileDialog.ShowDialog() != null)
                {
                    Stream s;
                    
                    //  If the opened file is valid
                    if ((s = fileDialog.OpenFile()) != null)
                    {
                        //  Read the file
                        using (StreamReader sr = new StreamReader(s))
                        {
                            //  Add the read text to our scintilla object
                            Highlighting.Highlighting.AddText(sr.ReadToEnd());
                            //  Assign the windowsformshost child
                            wfHost.Child = Highlighting.Highlighting.LanguageEditor;
                            
                            //  Different method
                            //webBrowser.NavigateToString(new CodeColorizer().Colorize(sr.ReadToEnd(), Languages.CSharp));
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        //  Windowsformshost loading handler
        private void wfHost_Loaded(object sender, RoutedEventArgs e)
        {
            Highlighting.Highlighting.Initialise();
        }
    }
}