using Expense_Tracker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    public class SignUpViewModel : Observable
    {
        private readonly MainViewModel _mainViewModel;

        public ICommand GoToLoginCommand { get; }

        public SignUpViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            GoToLoginCommand = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView =
                    new LoginViewModel(_mainViewModel);
            });
        }
    }
}
