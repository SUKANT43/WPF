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

namespace Counter.Controller
{
    /// <summary>
    /// Interaction logic for ButtonController.xaml
    /// </summary>
    public partial class ButtonController : UserControl
    {
        public ButtonController()
        {
            InitializeComponent();
        }

        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register(
                nameof(AddCommand),
                typeof(ICommand),
                typeof(ButtonController),
                new PropertyMetadata(null)
                );

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
             DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ButtonController),
                new PropertyMetadata(null)
                );

    }
}
