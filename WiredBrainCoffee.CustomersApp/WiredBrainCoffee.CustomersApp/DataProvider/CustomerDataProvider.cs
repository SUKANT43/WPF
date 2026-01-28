using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.DataProvider
{
    class CustomerDataProvider
    {
        static string folderPath = @"C:\Users\SEZ-A4\Desktop\Wpf\WPF";
        static string filePath = Path.Combine(folderPath, "customers.txt");

        public async Task<IEnumerable<Customer>> LoadCustomerAsync()
        {
            if (!File.Exists(filePath))
            {
                return GetDefaultCustomers();
            }

            var lines = File.ReadAllLines(filePath);
            var customers = new List<Customer>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');

                customers.Add(new Customer
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    IsDeveloper = bool.Parse(parts[2])
                });
            }

            return customers;
        }

        private List<Customer> GetDefaultCustomers()
        {
            return new List<Customer>
            {
                new Customer { FirstName = "Thomas", LastName = "Smith", IsDeveloper = true },
                new Customer { FirstName = "Julia", LastName = "Brown", IsDeveloper = false },
                new Customer { FirstName = "Anna", LastName = "White", IsDeveloper = true }
            };
        }
    }
}
