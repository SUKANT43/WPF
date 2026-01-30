using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(nameof(Customer))]
    public partial class CustomerDetailControl : UserControl
    {
        private bool _isInternalUpdate;

        public CustomerDetailControl()
        {
            InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register(
                nameof(Customer),
                typeof(Customer),
                typeof(CustomerDetailControl),
                new PropertyMetadata(null, CustomerChangedCallback));

        private static void CustomerChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomerDetailControl c)
            {
                c._isInternalUpdate = true;

                var customer = e.NewValue as Customer;

                c.txtFirstName.Text = customer?.FirstName ?? "";
                c.txtLastName.Text = customer?.LastName ?? "";
                c.chkIsDeveloper.IsChecked = customer?.IsDeveloper;

                c._isInternalUpdate = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            if (Customer == null || _isInternalUpdate)
                return;

            Customer.FirstName = txtFirstName.Text;
            Customer.LastName = txtLastName.Text;
            Customer.IsDeveloper = chkIsDeveloper.IsChecked == true;
        }
    }
}
