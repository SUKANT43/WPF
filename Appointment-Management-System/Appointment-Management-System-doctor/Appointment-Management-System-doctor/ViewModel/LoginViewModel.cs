using Appointment_Management_System_doctor.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Appointment_Management_System_doctor.ViewModel
{
    public class LoginViewModel
    {
        public MainWindowViewModel _mainWindowViewModel;
        public ICommand GoToSignUpCommand { get; }
        public LoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            GoToSignUpCommand = new RelayCommand(o =>
              {
                  _mainWindowViewModel.CurrentView = new SignUpViewModel(_mainWindowViewModel);
              });
        }
    }
}
