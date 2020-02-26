# How to maintain the DetailsView expanded state when Sorting and Grouping the DataGrid SfDataGrid
How to maintain the DetailsView expanded state when Sorting and Grouping the DataGrid (SfDataGrid)?

By default, when we are processing the data operation (Grouping, Sorting) the expanded DetailsViewDataGrid is collapsed in SfDataGrid. 

### Grouping
We can expand all the DetailsViewDataGrid when processing the grouping in SfDataGrid.GroupColumnDescriptions.CollectionChanged. 

```C#
this.dataGrid.GroupColumnDescriptions.CollectionChanged += GroupColumnDescriptions_CollectionChanged;

private void GroupColumnDescriptions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
    dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
         new Action(() =>
         {
             this.dataGrid.ExpandAllDetailsView();
         }));
}
```
### Sorting
We can expand all the DetailsViewDataGrid when processing sorting in SfDataGrid.SortColumnsChanged. 
``` C#
this.dataGrid.SortColumnsChanged += DataGrid_SortColumnsChanged;

private void DataGrid_SortColumnsChanged(object sender, GridSortColumnsChangedEventArgs e)
{
    dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
         new Action(() =>
         {
             this.dataGrid.ExpandAllDetailsView();
         }));
}
```
