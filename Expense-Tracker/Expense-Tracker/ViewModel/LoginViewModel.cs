using Expense_Tracker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    class LoginViewModel:Observable
    {
        private readonly MainViewModel _mainViewModel;
        public ICommand GoToSignUpCommand { get; }

        public LoginViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            GoToSignUpCommand = new RelayCommand(o =>
              {
                  _mainViewModel.CurrentView =
                  new SignUpViewModel(_mainViewModel);
              });
        }
    }
}
