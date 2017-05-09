using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TestWindow
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            richTextBox.IsEnabled = true;
        }

        private string rtbGetText(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }

        private void rtbSetText(RichTextBox rtb, string text)
        {
            rtb.Document.Blocks.Clear();
            rtb.Selection.Text = text;
        }

        private void insert_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "c# files|*.cs";

            if (fileDialog.ShowDialog() != null)
            {
                Stream s;
                
                if ((s = fileDialog.OpenFile()) != null)
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        rtbSetText(richTextBox, string.Join("", sr.ReadToEnd().Split('\n')));
                    }

                    //MessageBox.Show(rtbGetText(richTextBox));
                }
            }
        }
    }
}