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

        private void Bubbling_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button clicked");
        }

        private void Bubbling_Panel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("panel clicked");
        }

        private void Tunneling_Panel_Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("panel mouse down");
        }

        private void Tunneling_Button_Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("button mouse down");
        }

        private void Direct_Text_Changed(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Text only changed");
        }
    }
}
