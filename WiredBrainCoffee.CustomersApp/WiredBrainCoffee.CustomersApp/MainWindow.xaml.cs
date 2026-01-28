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

namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            int currentColumn = Grid.GetColumn(customerContainer);

            if (currentColumn == 0)
            {
                Grid.SetColumn(customerContainer, 1);
             
                Grid.SetColumn(formContainer, 0);
            }
            else
            {
                Grid.SetColumn(customerContainer, 0);
                Grid.SetColumn(formContainer, 1);

            }
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
