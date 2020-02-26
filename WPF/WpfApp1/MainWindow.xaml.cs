using Syncfusion.UI.Xaml.Grid;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid.Loaded += DataGrid_Loaded;
            this.dataGrid.AutoExpandGroups = true;
            this.dataGrid.GroupColumnDescriptions.CollectionChanged += GroupColumnDescriptions_CollectionChanged;
            this.dataGrid.SortColumnsChanged += DataGrid_SortColumnsChanged;
        }

        private void DataGrid_SortColumnsChanged(object sender, GridSortColumnsChangedEventArgs e)
        {
            dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
                 new Action(() =>
                 {
                     this.dataGrid.ExpandAllDetailsView();
                 }));
        }
        
        private void GroupColumnDescriptions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
                 new Action(() =>
                 {
                     this.dataGrid.ExpandAllDetailsView();
                 }));
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.dataGrid.ExpandAllDetailsView();
        }
    }
}
