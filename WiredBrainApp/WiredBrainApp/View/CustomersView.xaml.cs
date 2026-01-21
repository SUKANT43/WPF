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
using WiredBrainApp.ViewModel;
using WiredBrainApp.Data;
namespace WiredBrainApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {

        private CustomersViewModel viewModel;
        public CustomersView()
        {
            InitializeComponent();
            viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = viewModel;
            Loaded += CustomerViewLoaded;
        }

        private async void CustomerViewLoaded(object s,RoutedEventArgs e)
        {
            await viewModel.LoadAsync();
        }

        private void ButtonMoveNavigationClick(object sender, RoutedEventArgs e)
        {
            //var col = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            //var newColumn = col == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            var col = Grid.GetColumn(customerListGrid);
            var newCol = col == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newCol);

        }

    }
}
