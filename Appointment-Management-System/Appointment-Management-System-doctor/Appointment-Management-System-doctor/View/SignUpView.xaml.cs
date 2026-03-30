using Appointment_Management_System_doctor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Appointment_Management_System_doctor.View
{
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();

            passwordBox.PasswordChanged += PasswordBoxPasswordChanged;
            confirmPasswordBox.PasswordChanged += ConfirmPasswordChanged;
        }

        private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignUpViewModel vm)
            {
                vm.Password = passwordBox.Password;
            }
        }

        private void ConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignUpViewModel vm)
            {
                vm.ConfirmPassword = confirmPasswordBox.Password;
            }
        }
    }
}