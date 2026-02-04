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
    }
}
