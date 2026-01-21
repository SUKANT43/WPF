using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WiredBrainApp.Data
{

    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Model.Customer>> GetAllAsync();
    }

    class CustomerDataProvider:ICustomerDataProvider
    {
        public async Task<IEnumerable<Model.Customer>> GetAllAsync()
        {
            await Task.Delay(100);
            return new List<Model.Customer>
            {
                new Model.Customer { Id = 1, FirstName = "Julia", LastName = "Developer", IsDeveloper = true },
                new Model.Customer { Id = 2, FirstName = "Alex", LastName = "Rider" },
                new Model.Customer { Id = 3, FirstName = "Thomas Claudius", LastName = "Huber", IsDeveloper = true },
                new Model.Customer { Id = 4, FirstName = "Anna", LastName = "Rockstar" },
                new Model.Customer { Id = 5, FirstName = "Sara", LastName = "Metroid" },
                new Model.Customer { Id = 6, FirstName = "Ben", LastName = "Ronaldo" }
            };
        }
    }
}
