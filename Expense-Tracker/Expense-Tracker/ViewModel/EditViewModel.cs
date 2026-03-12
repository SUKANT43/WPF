using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expense_Tracker.Model;
namespace Expense_Tracker.ViewModel
{
    public class EditViewModel
    {
        private MainViewModel _mainViewModel;
        public DataModel selectedData;
        public EditViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
