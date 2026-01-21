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
using MvvmBasics.ViewModel;
namespace MvvmBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window { 
        //CustomerViewModel vm = new CustomerViewModel();
        ToDoViewModel tm = new ToDoViewModel();

        public MainWindow()
        {
            InitializeComponent();
            // DataContext = vm;
            DataContext = tm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // vm.SaveCustomer();
            tm.AddList();
            //foreach(var l in tm.Lst)
            //{
            //    MessageBox.Show(l.Content);
            //}
        }
    }
}
