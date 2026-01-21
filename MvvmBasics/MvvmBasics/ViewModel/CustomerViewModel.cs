using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmBasics.Model;

namespace MvvmBasics.ViewModel
{
    class CustomerViewModel:INotifyPropertyChanged
    {
        private string customerName;
        private string statusMessage;

        public string CustomerName
        {
            get => customerName;
            set { customerName = value; OnPropertyChanged(); }
        }

        public string StatusMessage
        {
            get => statusMessage;
            set { statusMessage = value; OnPropertyChanged(); }
        }

        public void SaveCustomer()
        {
            Customer cs = new Customer { Name = customerName };
            StatusMessage = "Saved:" + cs.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
