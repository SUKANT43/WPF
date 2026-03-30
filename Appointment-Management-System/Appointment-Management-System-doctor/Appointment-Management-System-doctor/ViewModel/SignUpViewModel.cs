using Appointment_Management_System_doctor.Base;
using Appointment_Management_System_doctor.Handler;
using Appointment_Management_System_doctor.Model;
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
    public class SignUpViewModel:Observable
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ICommand GoToLoginCommand { get; }
        public ICommand SignupCommand { get; }
        public SignUpViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            GoToLoginCommand = new RelayCommand(o => {
                _mainWindowViewModel.CurrentView = new LoginViewModel(_mainWindowViewModel);
            });
            SignupCommand = new RelayCommand(o => { SignUp(); });
        }

        public string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public void SignUp()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                Message = "Please fill all fields";
                return;
            }

            if (!EmailHandler.IsValid(Email))
            {
                Message = "Email must be in correct format";
                return;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Password and Confirm Password dose't match";
                return;
            }

            if (!DBHandler.IsTableExist("Users"))
            {
                DBHandler.CreateTable("Users", new ColumnDetails[]
                {
                    new ColumnDetails("ID"){DataType=BaseDatatypes.SMALLINT,TypeOfIndex=IndexType.PrimaryKey,IsAutoIncrement=true},
                    new ColumnDetails("Name"){DataType=BaseDatatypes.VARCHAR,Length=200},
                    new ColumnDetails("Email"){DataType=BaseDatatypes.VARCHAR,Length=200},
                    new ColumnDetails("Password"){DataType=BaseDatatypes.VARCHAR,Length=250},
                });
            }

            BooleanMsg<object> isContains =
                DBHandler.IsContains("Users", "Email", $"Email='{Email}'");

            if (isContains.Value!=null&&isContains.Value.ToString()==Email)
            {
                Message = "Email already exist";
                return;
            }
            string hashedPassword=PasswordHandler.HashPassword(Password);
            BooleanMsg add = DBHandler.AddData("Users", new ParameterData[]
            {
                new ParameterData("Name",$"{Name}"),
                new ParameterData("Email",$"{Email}"),
                new ParameterData("Password",$"{hashedPassword}"),

            });
            Message = "Account created successfully.";
            _mainWindowViewModel.CurrentView = new LoginViewModel(_mainWindowViewModel);
        }

    }
}
