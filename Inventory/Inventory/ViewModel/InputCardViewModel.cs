using Inventory.Base;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Inventory.ViewModel
{
    public class InputCardViewModel:Observable
    {
        private readonly InventoryViewModel _inventoryVM;

        private string _productName;
        private double _originalPrice;
        private double _offeredPrice;
        private double _gSTpercentage;

       

        public string ProductName
        {
            get => _productName;
            set{
                _productName = value;
                OnPropertyChanged();
            }
        }

        public Double OriginalPrice
        {
            get => _originalPrice;
            set
            {
                _originalPrice = value;
                OnPropertyChanged();
            }
        }

        public Double GSTpercentage
        {
            get => _gSTpercentage;
            set
            {
                _gSTpercentage = value;
                OnPropertyChanged();
            }
        }

        public Double OfferedPrice
        {
            get => _offeredPrice;
            set
            {
                _offeredPrice = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public InputCardViewModel(InventoryViewModel inventoryVM)
        {
            _inventoryVM = inventoryVM;
            SaveCommand = new RelayCommand(SaveItem);
        }

        private void SaveItem()
        {
            var newItem = new InventoryModel(
                ProductName,
                OriginalPrice,
                OfferedPrice,
                GSTpercentage
            );


            _inventoryVM.Products.Add(newItem);

            //foreach(var ls in _inventoryVM.Products)
            //{
            //    MessageBox.Show(ls.ProductName);
            //}

            ProductName = string.Empty;
            OriginalPrice = 0;
            OfferedPrice = 0;
            GSTpercentage = 0;
        }
    }
}
