using Expense_Tracker.Base;
using Expense_Tracker.Session;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    public class MainViewModel : Observable
    {
        public ICommand NavigateToReportCommand { get; }
        public ICommand NavigateToHomeCommand { get; }
        private bool _isVisible = false;
        private object _currentView;

        public MainViewModel()
        {
            CurrentView = new LoginViewModel(this);

            NavigateToReportCommand = new RelayCommand(o => NavigateToReport());
            NavigateToHomeCommand = new RelayCommand(o => NavigateToHome());
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(ProfileLetter));
                IsVisible = UserSession.CurrentUser != null;
            }
        }

        private void NavigateToReport()
        {
            CurrentView = new ReportViewModel(this);
        }

        private void NavigateToHome()
        {
            CurrentView = new HomeViewModel(this);
        }

        public string Name
        {
            get
            {
                if (UserSession.CurrentUser == null || string.IsNullOrEmpty(UserSession.CurrentUser.Name))
                    return "";

                return UserSession.CurrentUser.Name.ToUpper();
            }
        }

        public char ProfileLetter
        {
            get
            {
                if (UserSession.CurrentUser == null || string.IsNullOrEmpty(UserSession.CurrentUser.Name))
                    return ' ';

                return char.ToUpper(UserSession.CurrentUser.Name[0]);
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

    }
}