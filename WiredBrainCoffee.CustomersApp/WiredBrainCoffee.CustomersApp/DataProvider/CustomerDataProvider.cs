using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Base;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.DataProvider
{
    class CustomerDataProvider
    {
        private static readonly string folderPath = @"C:\Users\SEZ-A4\Desktop\Wpf\WPF";
        private static readonly string filePath = Path.Combine(folderPath, "customers.txt");

        public async Task<IEnumerable<Customer>> LoadCustomerAsync()
        {
            if (!File.Exists(filePath))
                return GetDefaultCustomers();

            var lines = File.ReadAllLines(filePath);
            var customers = new List<Customer>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length != 3) continue;

                customers.Add(new Customer
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    IsDeveloper = bool.Parse(parts[2])
                });
            }

            return customers;
        }

        public async Task SaveCustomerAsync(Customer customer)
        {
            Directory.CreateDirectory(folderPath);

            string line = $"{customer.FirstName},{customer.LastName},{customer.IsDeveloper}";
            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        public async Task SaveAllCustomersAsync(IEnumerable<Customer> customers)
        {
            var lines = customers.Select(c =>
                $"{c.FirstName},{c.LastName},{c.IsDeveloper}");

            File.WriteAllLines(filePath, lines);
        }

        private IEnumerable<Customer> GetDefaultCustomers()
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
