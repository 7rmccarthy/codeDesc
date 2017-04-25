using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace codeDesc
{
    /// <summary>
    /// Interaktionslogik für TabControl.xaml
    /// </summary>
    public partial class TabControl : UserControl
    {
        public List<TabItem> tabItems = new List<TabItem>();
        public List<string> tabcontent = new List<string>();
        public TabControl()
        {
            InitializeComponent();
            //// add a tabItem with + in header 
            TabItem tab = new TabItem();
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.ContentTemplate = tabDynamic.FindResource("TabItem") as DataTemplate;
            tab.Header = "TAB";

            tabItems.Add(tab);
            AddTabItem("Name");
            // add first tab
            //this.AddTabItem();

            // bind tab control
            tabDynamic.DataContext = tabItems;

            tabDynamic.SelectedIndex = 0;
        }
        #region TabControl
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (tabItems.Count < 2)
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

                    tabItems.Remove(tab);

                    // bind tab control
                    tabDynamic.DataContext = tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
        }
        public void AddTabItem(string tabname)
        {
            int count = tabItems.Count;
            //string name = "";
            //AddTabDialog addtabwindow = new AddTabDialog();
            //addtabwindow.ShowDialog();
            //if (addtabwindow.DialogResult.Value)
            //{
            //    name = addtabwindow.output;
            //}
            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = string.Format(tabname);
            tab.Name = string.Format(tabname);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.ContentTemplate = tabDynamic.FindResource("TabItem") as DataTemplate;

            

            // insert tab item right before the last (+) tab item
            tabItems.Insert(count , tab);
            tabDynamic.DataContext = null;
            tabDynamic.DataContext = tabItems;
            tabDynamic.SelectedItem = tab;
        }
        #endregion 
    }
}
