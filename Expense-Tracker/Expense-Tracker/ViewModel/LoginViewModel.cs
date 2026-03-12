using Expense_Tracker.Base;
using Expense_Tracker.Services;
using Expense_Tracker.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    class LoginViewModel:Observable
    {
        private readonly MainViewModel _mainViewModel;
        public ICommand GoToSignUpCommand { get; }
        public ICommand GoToHomeCommand { get; }
        public LoginViewModel(MainViewModel mainViewModel)
        {
            ErrorMessage = "";
            _mainViewModel = mainViewModel;
            GoToHomeCommand = new RelayCommand(o => Login());
            GoToSignUpCommand = new RelayCommand(o =>
              {
                  _mainViewModel.CurrentView =
                  new SignUpViewModel(_mainViewModel);
              });
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnCheck();
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnCheck();
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private void Login()
        {
            if (!Validate())
            {
                return;
            }

            var result = UserService.LoginUser(Email, Password);

            if (!result.IsSuccess)
            {
                ErrorMessage = result.Message;
                return;
            }

            UserSession.CurrentUser = result.User;

            ErrorMessage = "Account login successfully!";

            _mainViewModel.CurrentView=new HomeViewModel(_mainViewModel);
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "All fields must contain values.";
                return false;
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Invalid email format.";
                return false;
            }

            ErrorMessage = "";
            return true;
        }
    

        public void OnCheck()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "All fields must contain values.";
                return;
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Invalid email format.";
                return;
            }

            ErrorMessage = "";
        }

        private bool IsValidEmail(string email)
         {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
