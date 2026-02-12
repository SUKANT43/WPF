using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public class InventoryModel
    {
        private static int idGenerator = 101;

        public int Id { get; set; }
        public string ProductName { get; set; }
        public double OriginalPrice { get; set; }
        public double OfferedPrice { get; set; }
        public double GSTpercentage { get; set; }

        public InventoryModel(string productName,double originalPrice,double offeredPrice,double gstPercentage)
        {
            Id = idGenerator++;
            ProductName = productName;
            OriginalPrice = originalPrice;
            OfferedPrice = offeredPrice;
            GSTpercentage = gstPercentage;
        }

    }
}

