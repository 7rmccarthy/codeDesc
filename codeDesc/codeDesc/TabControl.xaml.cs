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
    /// Interaktionslogik für TabControl.xaml
    /// </summary>
    public partial class TabControl : UserControl
    {
        public List<TabItem> tabItems = new List<TabItem>();
        public TabControl()
        {
            InitializeComponent();
            // add a tabItem with + in header 
            TabItem tabAdd = new TabItem();
            tabAdd.Header = "+";

            tabItems.Add(tabAdd);

            // add first tab
            this.AddTabItem();

            // bind tab control
            tabDynamic.DataContext = tabItems;

            tabDynamic.SelectedIndex = 0;
        }
        #region TabControl
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    tabDynamic.DataContext = tabItems;

                    // select newly added tab item
                    tabDynamic.SelectedItem = newTab;
                }
                else
                {

                }
            }
        }
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (tabItems.Count < 3)
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
        private TabItem AddTabItem()
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
            tab.Header = string.Format("Tab{0}", count);
            tab.Name = string.Format("Tab{0}", count);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;

            // add controls to tab item, this case I added just a textbox
            TextBox txt = new TextBox();
            txt.Name = "txt";
            tab.Content = txt;

            // insert tab item right before the last (+) tab item
            tabItems.Insert(count - 1, tab);
            return tab;
        }
        #endregion 
    }
}
