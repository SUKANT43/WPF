using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.ViewModel
{
    public class HomeViewModel
    {
        private MainViewModel _mainViewModel;
        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
