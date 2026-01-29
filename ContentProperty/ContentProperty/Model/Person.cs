using ContentProperty.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProperty.Model
{
    public class Person : Observable
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value;  OnPropertyChanged();  }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

    }
}
