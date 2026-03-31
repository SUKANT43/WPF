using Appointment_Management_System_doctor.Base;
using Appointment_Management_System_doctor.Handler;
using Appointment_Management_System_doctor.Model;
using Appointment_Management_System_doctor.View;
using DatabaseLibrary;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Appointment_Management_System_doctor.ViewModel
{
    public class LoginViewModel : Observable
    {
        public MainWindowViewModel _mainWindowViewModel;
        public ICommand GoToSignUpCommand { get; }
        public ICommand LoginCommand { get; }
        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            GoToSignUpCommand = new RelayCommand(o =>
              {
                  _mainWindowViewModel.CurrentView = new SignUpViewModel(_mainWindowViewModel);
              });

            LoginCommand = new RelayCommand(o => Login());

        }


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Message = "Please fill all fields.";
                return;
            }

            if (!EmailHandler.IsValid(Email))
            {
                Message = "Email must be in correct format";
                return;
            }

            BooleanMsg<object> isContains = DBHandler.GetSingleData("Users", "Email", $"Email='{Email}'");
            if (isContains.Value == null || isContains.Value.ToString() != Email)
            {
                Message = "Email not registered.";
                ((MainWindow)Application.Current.MainWindow)
                .GlobalNotification
                .ShowNotification("Email not registered.");
                return;
            }

            BooleanMsg<object> getPassword =
               DBHandler.GetSingleData("Users", "Password", $"Email='{Email}'");

            if (!PasswordHandler.VerifyPassword(Password,getPassword.Value.ToString()))
            {
                Message = "Wrong Password.";
                ((MainWindow)Application.Current.MainWindow)
                .GlobalNotification
                .ShowNotification("Wrong Password.");
                return;
            }
                ((MainWindow)Application.Current.MainWindow)
            .GlobalNotification
            .ShowNotification("Login successfully.");
            _mainWindowViewModel.CurrentView = new HomeViewModel(_mainWindowViewModel);

        }
    }
}
