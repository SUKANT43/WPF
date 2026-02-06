using Counter.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Model
{
    public class NameModel
    {
        private string _firstName;
        private IEnumerable<char> enumerable;
        private Func<IEnumerable<char>> reverse;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public NameModel(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        public NameModel()
        {

        }

        public NameModel(string firstName, IEnumerable<char> enumerable)
        {
            _firstName = firstName;
            this.enumerable = enumerable;
        }

        public NameModel(string firstName, Func<IEnumerable<char>> reverse)
        {
            _firstName = firstName;
            this.reverse = reverse;
        }
    }
}
