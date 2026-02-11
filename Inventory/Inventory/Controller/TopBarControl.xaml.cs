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

namespace Inventory.Controller
{
    /// <summary>
    /// Interaction logic for TopBarControl.xaml
    /// </summary>
    public partial class TopBarControl : UserControl
    {
        private bool _isDark;
        public TopBarControl()
        {
            InitializeComponent();
        }

        private void Theme_Button_Press(object sender, MouseEventArgs e)
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
