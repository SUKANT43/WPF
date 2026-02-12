using Inventory.Controller;
using Inventory.ViewModel;
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

namespace Inventory.View
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : Page
    {
        private InventoryViewModel _inventoryVM;

        public InventoryView()
        {
            InitializeComponent();
            _inventoryVM = new InventoryViewModel();
            DataContext = _inventoryVM;
            InputCard.DataContext = new InputCardViewModel(_inventoryVM);
        }


    }
}
