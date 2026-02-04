using Counter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ListController.xaml
    /// </summary>
    public partial class ListController : UserControl
    {
        public ListController()
        {
            InitializeComponent();
        }

        public ObservableCollection<NameModel> Names
        {
            get => (ObservableCollection<NameModel>)GetValue(NamesProperty);
            set => SetValue(NamesProperty, value);
        }


        public static readonly DependencyProperty NamesProperty = DependencyProperty.Register(
            nameof(Names),
            typeof(ObservableCollection<NameModel>),
            typeof(ListController),
            new PropertyMetadata(null)
          );

        public NameModel SelectedItem
        {
            get => (NameModel)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(NameModel),
                typeof(ListController),
                new PropertyMetadata(null)
            );

    }
}
