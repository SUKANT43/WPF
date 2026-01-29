using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WiredBrainCoffee.CustomersApp.Base;


namespace WiredBrainCoffee.CustomersApp.Model
{
    public sealed partial class Customer : Observable
    {
        private string _firstName;
        private string _lastName;
        private bool _isDeveloper;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDeveloper
        {
            get => _isDeveloper;
            set
            {
                if (_isDeveloper != value)
                {
                    _isDeveloper = value;
                    OnPropertyChanged();
                }
            }
        }
    }

}
