using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;

namespace codeDesc
{
    /// <summary>
    /// Interaktionslogik für New_Dialog.xaml
    /// </summary>
    public partial class New_Dialog : Window
    {
        public List<string> Filepaths = new List<string>();
        public string ProjectName;
        
        public New_Dialog()
        {
            InitializeComponent();
        }

        private void btn_import(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.Filter = "files (*.cs)|*.cs;";

            if (dlg.ShowDialog() == true)
            {
                foreach (var filename in dlg.FileNames)
                {
                    Filepaths.Add(filename);
                }
            }
        }

        private void btn_finish(object sender, RoutedEventArgs e)
        {
            
            if (txt_Project_Name.Text != "")
            {
                ProjectName = txt_Project_Name.Text;
                DialogResult = true;
            }               
            else
            {
                MessageBox.Show("Wrong Name");
                DialogResult = false;
            }
                

        }
    }
}
