using Expense_Tracker.Base;
using Expense_Tracker.Enums;
using Expense_Tracker.Model;
using Expense_Tracker.Services;
using Expense_Tracker.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Expense_Tracker.ViewModel
{
    public class HomeViewModel : Observable
    {
        private MainViewModel _mainViewModel;
        public ICommand AddTransactionCommand { get; }
        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            AddTransactionCommand = new RelayCommand(o => AddTransaction());
        }

        public Array TransactionTypes => Enum.GetValues(typeof(TransactionType));
        public Array Categories => Enum.GetValues(typeof(Category));

        private TransactionType _selectedTransactionType;

        public TransactionType SelectedTransactionType
        {
            get => _selectedTransactionType;
            set
            {
                _selectedTransactionType = value;
                OnPropertyChanged();
            }
        }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date = DateTime.Today;

        public DateTime Date
        {

            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private void AddTransaction()
        {
            var user = UserSession.CurrentUser;

            if (user == null)
                return;

            if (user.History == null)
                user.History = new List<DataModel>();

            var data = new DataModel
            {
                TransactionType = SelectedTransactionType,
                Amount = (double)Amount,
                Description = Description,
                Category = SelectedCategory,
                Date = Date
            };

            user.History.Add(data);

            UserService.SaveUser(user);
            SelectedTransactionType = TransactionType.Expense;
            SelectedCategory = Category.Food;
            Amount = 0;
            Description = string.Empty;
            Date = DateTime.Today;

        }


    }
}
