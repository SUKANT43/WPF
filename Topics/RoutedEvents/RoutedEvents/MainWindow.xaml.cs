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

namespace RoutedEvents
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

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("PreviewMouseDown → Window");
        }

        private void Panel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("PreviewMouseDown → StackPanel");
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("PreviewMouseDown → Button");
        }

        // -------- BUBBLING EVENTS --------
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("MouseDown → Button");
        }

        private void Panel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("MouseDown → StackPanel");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("MouseDown → Window");
        }

        // -------- DIRECT EVENT --------
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Loaded → Button (Direct Event)");
        }
    }
}
