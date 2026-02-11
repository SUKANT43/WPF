using Inventory.Base;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory.ViewModel
{
    public class InventoryViewModel : Observable
    {
        public ObservableCollection<InventoryModel> Products { get; }

        public InventoryViewModel()
        {
            Products = new ObservableCollection<InventoryModel>();
        }
    }
}
