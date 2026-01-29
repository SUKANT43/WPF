using ContentProperty.Base;
using ContentProperty.Data;
using ContentProperty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProperty.ViewModel
{
    class MainViewModel:Observable
    {
        public ObservableCollection<Person> People => PersonData.List;

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public void AddPerson()
        {
            var p = new Person { Name = "New Person", Age = 0 };
            People.Add(p);
            SelectedPerson = p;
        }

        public void DeletePerson()
        {
            if (SelectedPerson != null)
                People.Remove(SelectedPerson);
        }


    }
}
