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
    /// Interaction logic for FieldController.xaml
    /// </summary>
    public partial class FieldController : UserControl
    {
        public FieldController()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register(
                nameof(FirstName),
                typeof(string),
                typeof(FieldController),
                new PropertyMetadata(string.Empty)
                );

        public string FirstName
        {
            get => (string)GetValue(FirstNameProperty);
            set => SetValue(FirstNameProperty, value);
        }

        public static readonly DependencyProperty LastNameProperty =
             DependencyProperty.Register(
                nameof(LastName),
                typeof(string),
                typeof(FieldController),
                new PropertyMetadata(string.Empty)
                );

        public string LastName
        {
            get => (string)GetValue(LastNameProperty);
            set => SetValue(LastNameProperty, value);
        }

    }
}
