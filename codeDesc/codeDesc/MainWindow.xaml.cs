using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

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
        
        //Context Menu 
        private void btn_top_menu(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        #region File

        //New
        private void btn_top_menu_file_new(object sender, RoutedEventArgs e)
        {
            New_Dialog dl = new New_Dialog();
            TabControl tb = new TabControl();
            dl.ShowDialog();
            if (dl.DialogResult.Value)
            {
                if (dl.Filepaths != null)
                {
                    textBoxList.Clear();
                    foreach (var path in dl.Filepaths)
                    {
                        textBoxList.Add(Import(path));
                        tb.AddTabItem(path.Substring(path.LastIndexOf('\\')+1));
                    }
                }
                HomeVis = Visibility.Collapsed;
                TCVis = Visibility.Visible;
            }         
            TextBoxContent = textBoxList[0];

        }       

        //Open
        private void btn_top_menu_file_open(object sender, RoutedEventArgs e)
        {
            HomeVis = Visibility.Collapsed;
            TCVis = Visibility.Visible;
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.Filter= "files (*.cs)|*.cs;";
            if (dlg.ShowDialog() == true)
            {
                textBoxList.Clear();
                foreach(var filename in dlg.FileNames)
                {
                    textBoxList.Add(Import(filename));
                }
            }
            textBoxContent = textBoxList[0];
        }

        //Save
        private void btn_top_menu_file_save(object sender, RoutedEventArgs e)
        {

        }

        #endregion File

        #region Edit

        private void btn_Edit_(object sender, RoutedEventArgs e)
        {

        }


        #endregion Edit

        #region View

        private void btn_View_(object sender, RoutedEventArgs e)
        {

        }

        #endregion View

        #region Help

        //Open Help Window
        private void btn_Help_Open(object sender, RoutedEventArgs e)
        {

        }

        //Support 
        private void btn_Help_Support(object sender, RoutedEventArgs e)
        {

        }

        //Send Feedback
        private void btn_Help_Feedback(object sender, RoutedEventArgs e)
        {

        }

        //Report Bug
        private void btn_Help_BugReport(object sender, RoutedEventArgs e)
        {

        }

        #endregion Help

        #region About

        private void btn_about(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion About

        #endregion Actionbar

        #region ProjectSolution

        public bool IsProjectSolutionVisible = true;

        private void btn_project_solution(object sender, RoutedEventArgs e)
        {
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

        //Binding Image Source (Calvin Metzger)
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
        #endregion

        #region TabControl TextBoxContent

        //TabItemChange (Calvin Metzger)

        //TabContent
        public List<string> textBoxList = new List<string>();
        
        private string textBoxContent;

        //Binding Richtextbox
        public string TextBoxContent
        {
            get
            {
                return textBoxContent;
            }
            set
            {
                textBoxContent = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBoxContent)));
            }
        }

        //Event TabItemChanged
        private void TC_uc_TabItemChanged(object sender, TabItemEventArgs e)
        {
            if (textBoxList.Count <= e.OldIndex+1)
            {
                textBoxList.Add(TextBoxContent);
            }       
            else
            {
                textBoxList[e.OldIndex] = TextBoxContent;
            }
            this.TextBoxContent = this.textBoxList[e.Index];
        }
        public static Highlighting h = new Highlighting();
        //Convert String to Document
        public static FlowDocument StringToDocument(string text)
        {   
                return h.createDocument(text);
        }

        //Convert Document to String 
        public string DocumentToString(FlowDocument document)
        {
            var textRange = new TextRange(document.ContentStart, document.ContentEnd);
            return textRange.Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public TabControl ucTabControl = new TabControl();
        

        #endregion

        #region UserControl

        //Home
        public Visibility hscreen = Visibility.Visible;
        
        //TabControl
        public Visibility tcscreen = Visibility.Collapsed;

        //Binding Visibility Home UserControl (Calvin Metzger)
        public Visibility HomeVis
        {
            get { return hscreen; }
            set { hscreen = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HomeVis)));}
        }

        //Binding Visibility TabControl UserControl (Calvin Metzger)
        public Visibility TCVis
        {
            get { return tcscreen; }
            set { tcscreen = value;this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TCVis)));}
        }

        #endregion      

        //Import .cs File
        private string Import (string filePath)
        {
            FlowDocument doc = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            try
            {
                // Create an instance of StreamReader to read from file.
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {                       
                        doc.Blocks.Add(new Paragraph(new Run(line)));                       
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong...");
                Console.WriteLine(e.Message);
            }
            return DocumentToString(doc);
        }
    }
}