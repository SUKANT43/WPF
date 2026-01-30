using System.Linq;
using System.Windows;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;
using System;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Controls;

namespace WiredBrainCoffee.CustomersApp
{
    public partial class MainWindow : Window
    {
        private CustomerDataProvider _customerDataProvider;
        private bool _isDarkTheme = false;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
            _customerDataProvider = new CustomerDataProvider();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            customerListView.Items.Clear();

            var customers = await _customerDataProvider.LoadCustomerAsync();
            foreach (var customer in customers)
            {
                customerListView.Items.Add(customer);
            }
        }

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await _customerDataProvider.SaveAllCustomersAsync(
                customerListView.Items.OfType<Customer>());
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "" };
            customerListView.Items.Add(customer);
            customerListView.SelectedItem = customer;
        }

        private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            if (customer != null)
            {
                customerListView.Items.Remove(customer);
            }
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(customerListGrid);
            int newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColumn);
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            var dicts = Application.Current.Resources.MergedDictionaries;

            for (int i = dicts.Count - 1; i >= 0; i--)
            {
                if (dicts[i].Source?.OriginalString.Contains("ThemeDictionary") == true)
                {
                    dicts.RemoveAt(i);
                }
            }

            dicts.Add(new ResourceDictionary
            {
                Source = new Uri(
                    _isDarkTheme
                        ? "Resources/LightThemeDictionary.xaml"
                        : "Resources/DarkThemeDictionary.xaml",
                    UriKind.Relative)
            });

            _isDarkTheme = !_isDarkTheme;
        }
    }
}
