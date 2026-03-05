using Expense_Tracker.Base;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    public class MainViewModel : Observable
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentView = new LoginViewModel(this);
        }
    }
}