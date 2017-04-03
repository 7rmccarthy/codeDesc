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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Boolean hscreen = true;
        public Boolean IsProjectSolutionVisible = true;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        #region ActionBar
        private void btn_top_menu(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        
        #region ProjectSolution
        private void btn_project_solution(object sender, RoutedEventArgs e)
        {
            if (IsProjectSolutionVisible)
            {
                this.Grid_ProjectSolution_width.Width = new GridLength(0, GridUnitType.Pixel);
                IsProjectSolutionVisible = false;
            }
            else
            {
                this.Grid_ProjectSolution_width.Width = new GridLength(250,GridUnitType.Pixel);
                IsProjectSolutionVisible = true;
            }


        }
        #endregion


        #region UserControl
        
        #endregion
    }
}

