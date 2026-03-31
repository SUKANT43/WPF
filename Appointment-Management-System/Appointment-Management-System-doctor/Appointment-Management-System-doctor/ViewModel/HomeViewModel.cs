using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.ViewModel
{
    public class HomeViewModel
    {
        private MainWindowViewModel _mainWindowViewModel;
        public HomeViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
    }
}
