using Expense_Tracker.Enums;
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

        public Array TransactionTypes => Enum.GetValues(typeof(TransactionType));
        public Array Categories => Enum.GetValues(typeof(Category));

        public TransactionType SelectedTransactionType { get; set; }

        public Category SelectedCategory { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;


    }
}
