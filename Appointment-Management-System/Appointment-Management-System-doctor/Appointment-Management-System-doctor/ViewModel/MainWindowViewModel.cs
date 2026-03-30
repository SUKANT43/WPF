using Appointment_Management_System_doctor.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.ViewModel
{
    public class MainWindowViewModel: Observable
    {
        private object _currentView;

        public MainWindowViewModel()
        {
            CurrentView = new LoginViewModel(this);
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
    }
}
