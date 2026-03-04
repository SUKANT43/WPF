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

namespace Expense_Tracker.Component
{
    /// <summary>
    /// Interaction logic for TopBarComponent.xaml
    /// </summary>
    public partial class TopBarComponent : UserControl
    {
        public TopBarComponent()
        {
            InitializeComponent();
        }

        private bool _isDarkMode = false;

        private void ThemeToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            var appResources = Application.Current.Resources.MergedDictionaries;

            appResources.Clear();

            if (_isDarkMode)
            {
                appResources.Add(
                    new ResourceDictionary
                    {
                        Source = new Uri("ThemeResources/LightTheme.xaml", UriKind.Relative)
                    });

                themeText.Text = "🌙";
                themeText.Foreground = Brushes.Black;
            }
            else
            {
                appResources.Add(
                    new ResourceDictionary
                    {
                        Source = new Uri("ThemeResources/DarkTheme.xaml", UriKind.Relative)
                    });

                themeText.Text = "☀";
                themeText.Foreground = Brushes.Orange;
            }

            _isDarkMode = !_isDarkMode;
        }
    }
}
