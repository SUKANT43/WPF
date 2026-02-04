using Counter.Base;
using Counter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Counter.ViewModel
{
    class NameViewModel:Observable
    {
        private string _firstName="";
        private string _lastName = "";

        private NameModel _selectedItem;
        public NameModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NameModel> Names { get; private set; }


        public void Add()
        {
            Names.Add(new NameModel(_firstName, _lastName));
        }

        public void Remove()
        {
            Names.Remove(_selectedItem);
        }

        public NameViewModel()
        {
            Names = new ObservableCollection<NameModel>();


            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

    }
}
