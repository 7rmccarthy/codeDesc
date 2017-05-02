using System;
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
        public event EventHandler<TabItemEventArgs> TabItemChanged;
        public List<TabItem> tabItems = new List<TabItem>();
        public int selected_tab=1;
        public TabControl()
        {
            InitializeComponent();
            TabItem tab = new TabItem();
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.ContentTemplate = tabDynamic.FindResource("TabItem") as DataTemplate;
            tab.Header = "Tab";
            tabItems.Add(tab);
            
            tabDynamic.DataContext = tabItems;
            tabDynamic.SelectedIndex = 0;
        }
        

        #region TabControl

        //(Calvin Metzger)
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItemChanged?.Invoke(this, new TabItemEventArgs(tabDynamic.SelectedIndex,selected_tab));
            selected_tab = tabDynamic.SelectedIndex;
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
            TabItem tab = new TabItem();
            tab.Header = string.Format(tabname);
            tab.Name = string.Format(tabname.Substring(0,tabname.LastIndexOf('.')));
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.ContentTemplate = tabDynamic.FindResource("TabItem") as DataTemplate;

            // insert tab item right before the last (+) tab item
            tabItems.Insert(count, tab);
            tabDynamic.DataContext = null;
            tabDynamic.DataContext = tabItems;
            tabDynamic.SelectedItem = tab;
        }
        #endregion 
    }

    
}
