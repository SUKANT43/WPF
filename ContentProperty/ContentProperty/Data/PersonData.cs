using ContentProperty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProperty.Data
{
    public static  class PersonData
    {
        public static ObservableCollection<Person> List { get; } = new ObservableCollection<Person>();

    }
}
