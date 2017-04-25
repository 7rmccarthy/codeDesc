using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace codeDesc
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {     
        public MainWindow()
        {
            InitializeComponent();
            HomeVis = Visibility.Visible;
            TCVis = Visibility.Collapsed;
        }

        #region ActionBar
        private void btn_top_menu(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
       
        private void btn_top_menu_file_new(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New");
            HomeVis = Visibility.Collapsed;
            TCVis = Visibility.Visible;
            
        }
        private void btn_top_menu_file_open(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open");
            HomeVis = Visibility.Visible;
            TCVis = Visibility.Collapsed;
            
        }
        private void btn_top_menu_file_save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save");
        }

        #endregion

        #region ProjectSolution
        public bool IsProjectSolutionVisible = true;
        private void btn_project_solution(object sender, RoutedEventArgs e)
        {
            tb.AddTabItem("NewTab");
            Console.WriteLine("true");
            if (IsProjectSolutionVisible)
            {
                this.Grid_ProjectSolution_width.Width = new GridLength(0, GridUnitType.Pixel);
                this.GridSplitter.Width = 0;
                IsProjectSolutionVisible = false;
            }
            else
            {
                this.Grid_ProjectSolution_width.Width = new GridLength(250,GridUnitType.Pixel);
                this.GridSplitter.Width = 5;
                IsProjectSolutionVisible = true;
            }
        }
        #endregion

        #region Icon
        private ImageSource iconSource = new ImageSourceConverter().ConvertFromString("../../Icons/Maximize_btn.png") as ImageSource;
        public ImageSource IconSource
        {
            get
            {
                return this.iconSource;
            }
            set
            {
                this.iconSource = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconSource)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region UserControl
        public Visibility hscreen = Visibility.Visible;
        public Visibility tcscreen = Visibility.Collapsed;
        public Visibility HomeVis
        {
            get { return hscreen; }
            set { hscreen = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HomeVis)));
            }
        }
        public Visibility TCVis
        {
            get { return tcscreen; }
            set { tcscreen = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TCVis)));
            }
        }
        public UserControl ucHome = new Home();
        public UserControl ucTabControl = new TabControl();
        public TabControl tb = new TabControl();
        #endregion       
    }
}

