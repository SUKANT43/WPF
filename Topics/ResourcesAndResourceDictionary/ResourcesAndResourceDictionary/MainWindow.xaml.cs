using System;
using System.Windows;

namespace ResourcesAndResourceDictionary
{
    public partial class MainWindow : Window
    {
        private bool _isDark;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[0] =
                new ResourceDictionary
                {
                    Source = new Uri(
                        _isDark
                            ? "Resources/LightTheme.xaml"
                            : "Resources/DarkTheme.xaml",
                        UriKind.Relative)
                };

            _isDark = !_isDark;
        }
    }
}
