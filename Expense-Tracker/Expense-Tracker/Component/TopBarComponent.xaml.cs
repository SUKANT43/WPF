using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Expense_Tracker.Component
{
    public partial class TopBarComponent : UserControl
    {
        public TopBarComponent()
        {
            InitializeComponent();
        }

        public ICommand NavigateToHomeCommand
        {
            get { return (ICommand)GetValue(NavigateToHomeCommandProperty); }
            set { SetValue(NavigateToHomeCommandProperty, value); }
        }

        public static readonly DependencyProperty NavigateToHomeCommandProperty =
            DependencyProperty.Register(
                nameof(NavigateToHomeCommand),
                typeof(ICommand),
                typeof(TopBarComponent),
                new PropertyMetadata(null));


        public ICommand NavigateToReportCommand
        {
            get { return (ICommand)GetValue(NavigateToReportCommandProperty); }
            set { SetValue(NavigateToReportCommandProperty, value); }
        }

        public static readonly DependencyProperty NavigateToReportCommandProperty =
            DependencyProperty.Register(
                nameof(NavigateToReportCommand),
                typeof(ICommand),
                typeof(TopBarComponent),
                new PropertyMetadata(null));


        private bool _isDarkMode = false;

        private void ThemeToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            var appResources = Application.Current.Resources.MergedDictionaries;
            appResources.Clear();

            if (_isDarkMode)
            {
                appResources.Add(new ResourceDictionary
                {
                    Source = new Uri("ThemeResources/LightTheme.xaml", UriKind.Relative)
                });

                themeText.Text = "🌙";
                themeText.Foreground = Brushes.Black;
            }
            else
            {
                appResources.Add(new ResourceDictionary
                {
                    Source = new Uri("ThemeResources/DarkTheme.xaml", UriKind.Relative)
                });

                themeText.Text = "☀";
                themeText.Foreground = Brushes.Orange;
            }

            _isDarkMode = !_isDarkMode;
        }

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register(
                nameof(UserName),
                typeof(string),
                typeof(TopBarComponent),
                new PropertyMetadata(string.Empty));


        public char ProfileLetter
        {
            get { return (char)GetValue(ProfileLetterProperty); }
            set { SetValue(ProfileLetterProperty, value); }
        }

        public static readonly DependencyProperty ProfileLetterProperty =
            DependencyProperty.Register(
                nameof(ProfileLetter),
                typeof(char),
                typeof(TopBarComponent),
                new PropertyMetadata(' '));

    }
}