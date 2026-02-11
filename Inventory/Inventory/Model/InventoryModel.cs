using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public class InventoryModel
    {
        public int Id;
        private static int idGenerator = 101;

        public string ProductName;
        public double OriginalPrice;
        public double OfferedPrice;
        public double GSTpercentage;


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
