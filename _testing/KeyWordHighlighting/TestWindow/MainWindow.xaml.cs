using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

namespace TestWindow
{
    public partial class MainWindow : Window 
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                InitializeComponent();

                // initialize tabItem array
                _tabItems = new List<TabItem>();

                // add a tabItem with + in header 
                TabItem tabAdd = new TabItem();
                tabAdd.Header = "+";

                _tabItems.Add(tabAdd);

                // add first tab
                this.AddTabItem();

                // bind tab control
                tabDynamic.DataContext = _tabItems;

                tabDynamic.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TabItem AddTabItem()
        {
            int count = _tabItems.Count;

            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = string.Format("Tab {0}", count);
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.ContentTemplate = tabDynamic.FindResource("TabItem") as DataTemplate;
            // add controls to tab item, this case I added just a textbox          

            // insert tab item right before the last (+) tab item
            _tabItems.Insert(count - 1, tab);
            return tab;
        }
        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;

            if (tab != null && tab.Header != null)
            {
                if (tab.Header.Equals("+"))
                {
                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    // add new tab
                    TabItem newTab = this.AddTabItem();

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select newly added tab item
                    tabDynamic.SelectedItem = newTab;
                }
                else
                {
                    // your code here...
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (_tabItems.Count < 3)
                {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // get selected tab
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    _tabItems.Remove(tab);

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
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
                            //wfHost.Child = Highlighting.Highlighting.LanguageEditor;
                            
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