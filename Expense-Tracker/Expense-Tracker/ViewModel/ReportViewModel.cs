using Expense_Tracker.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    public class ReportViewModel
    {
        private MainViewModel _mainViewModel;
        public ReportViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

    }
}
