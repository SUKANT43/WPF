using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmBasics.Model;

namespace MvvmBasics.ViewModel
{
    class ToDoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoData> Lst { get; set; }
            = new ObservableCollection<ToDoData>();

        private string content;
        public string Content
        {
            get => content;
            set { content = value; OnPropertyChanged(); }
        }

        public void AddList()
        {
            Lst.Add(new ToDoData(Content));
            Content = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
