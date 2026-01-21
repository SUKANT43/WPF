using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainApp.Model;
using WiredBrainApp.Data;

using System.Collections.ObjectModel;

namespace WiredBrainApp.ViewModel
{
    public class CustomersViewModel
    {
        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>(); //observable collection is helps to auto change in ui if the data is removed from the list
        private  ICustomerDataProvider customerDataProvider;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this.customerDataProvider = customerDataProvider;
        }

        public async Task LoadAsync()
        {
            var customers = await customerDataProvider.GetAllAsync();
            
            foreach(var customer in customers)
            {
                Customers.Add(customer);
            }
        }

    }


}
