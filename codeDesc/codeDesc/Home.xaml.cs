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

namespace codeDesc
{
    /// <summary>
    /// Interaktionslogik für Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click_newProject(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void Hyperlink_Click_openProject(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }
    }
}
