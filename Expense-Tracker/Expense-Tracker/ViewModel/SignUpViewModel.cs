using Expense_Tracker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Expense_Tracker.Services;
using Expense_Tracker.Model;

namespace Expense_Tracker.ViewModel
{
    public class SignUpViewModel : Observable
    {
        private readonly MainViewModel _mainViewModel;
        private UserService _userService;
        public ICommand GoToLoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public SignUpViewModel(MainViewModel mainViewModel)
        {
            ErrorMessage = "";
            _userService = new UserService();
            _mainViewModel = mainViewModel;
            RegisterCommand = new RelayCommand(o=>Register());
            GoToLoginCommand = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView =
                    new LoginViewModel(_mainViewModel);
            });
        }



        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                OnCheck();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                OnCheck();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                OnCheck();
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword=value;
                OnPropertyChanged();
                OnCheck();
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

        private void Register()
        {
            if (!Validate())
            {
                return;
            }

            if (_userService.UserExists(Email))
            {
                ErrorMessage = "Email already registered.";
                return;
            }

            var user = new UserModel
            {
                Name = Name,
                Email = Email,
                Password = Password
            };

            _userService.SaveUser(user);


            ErrorMessage = "Account created successfully!";
            _mainViewModel.CurrentView =
               new LoginViewModel(_mainViewModel);
        }

        public void OnCheck()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "All fields must contain values.";
                return;
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Invalid email format.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Password and Confirm Password must match.";
                return;
            }

            ErrorMessage = "";

        }


        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "All fields must contain values.";
                return false;
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Invalid email format.";
                return false;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Password and Confirm Password must match.";
                return false;
            }

            ErrorMessage = "";
            return true;
        }


        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public SignUpViewModel() { }
    }
    


}
