using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    public partial class CustomerDetailControl : UserControl
    {
        private Customer _customer;
        private bool _isInternalUpdate; // prevents recursive updates

        public CustomerDetailControl()
        {
            InitializeComponent();
        }

        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                _isInternalUpdate = true;

                txtFirstName.Text = _customer?.FirstName ?? "";
                txtLastName.Text = _customer?.LastName ?? "";
                chkIsDeveloper.IsChecked = _customer != null && _customer.IsDeveloper;

                _isInternalUpdate = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBox_IsCheckedChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            if (_customer == null || _isInternalUpdate)
                return;

            _customer.FirstName = txtFirstName.Text;
            _customer.LastName = txtLastName.Text;
            _customer.IsDeveloper = chkIsDeveloper.IsChecked == true;
        }
    }
}
