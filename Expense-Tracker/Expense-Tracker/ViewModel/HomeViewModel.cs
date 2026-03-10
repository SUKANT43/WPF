using Expense_Tracker.Base;
using Expense_Tracker.Enums;
using Expense_Tracker.Model;
using Expense_Tracker.Services;
using Expense_Tracker.Session;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand DeleteTransactionCommand { get; }
        public ICommand ClearFilterCommand { get; }
        private List<DataModel> _allTransactions = new List<DataModel>();
        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            AddTransactionCommand = new RelayCommand(o => AddTransaction());
            DeleteTransactionCommand = new RelayCommand(DeleteTransaction);
            ClearFilterCommand = new RelayCommand(o=>ClearFilter());
            var user = UserSession.CurrentUser;

            if (user?.History != null)
            {
                _allTransactions = user.History.ToList();
                Transactions = new ObservableCollection<DataModel>(_allTransactions);
            }
            else
            {
                Transactions = new ObservableCollection<DataModel>();
            }
            UpdateData();

        }

        private void ClearFilter()
        {
            FromDate = null;
            ToDate = null;
            SelectedFilterCategory = null;
            TransactionTypeFilterCategory = null;

            Transactions = new ObservableCollection<DataModel>(_allTransactions);
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
                Amount = (decimal)Amount,
                Description = Description,
                Category = SelectedCategory,
                Date = Date
            };

            user.History.Add(data);

            Transactions.Add(data);

            UserService.SaveUser(user);
            UpdateData();

            SelectedTransactionType = TransactionType.Expense;
            SelectedCategory = Category.Food;
            Amount = 0;
            Description = string.Empty;
            Date = DateTime.Today;
        }

        private ObservableCollection<DataModel> _transactions;

        public ObservableCollection<DataModel> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged();
            }
        }

        private void DeleteTransaction(object obj)
        {
            if (obj is DataModel data)
            {

                var result = MessageBox.Show(
                           "Are you sure you want to delete this transaction?",
                           "Confirm Delete",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Warning);

                if (result != MessageBoxResult.Yes)
                    return;

                var user = UserSession.CurrentUser;

                if (user == null)
                    return;

                user.History.Remove(data);
                Transactions.Remove(data);

                UserService.SaveUser(user);
                UpdateData();
                ApplyFilter();
            }
        }

        private decimal _balance;


        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged();
            }
        }

        public decimal _expense;

        public decimal Expense
        {
            get => _expense;
            set
            {
                _expense = value;
                OnPropertyChanged();
            }
        }

        public decimal _income;

        public decimal Income
        {
            get => _income;
            set
            {
                _income = value;
                OnPropertyChanged();
            }
        }

        private int _numberOfIncome;

        public int NumberOfIncome
        {
            get => _numberOfIncome;
            set
            {
                _numberOfIncome = value;
                OnPropertyChanged();
            }
        }

        private int _numberOfExpense;

        public int NumberOfExpense
        {
            get => _numberOfExpense;
            set
            {
                _numberOfExpense = value;
                OnPropertyChanged();

            }
        }

        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get => _fromDate;
            set
            {
                _fromDate = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }


        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get => _toDate;
            set
            {
                _toDate = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private Category? _selectedFilterCategory;
        public Category? SelectedFilterCategory
        {
            get => _selectedFilterCategory;
            set
            {
                _selectedFilterCategory = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        private TransactionType? _transactionTypeFilterCategory;
        public TransactionType? TransactionTypeFilterCategory
        {
            get => _transactionTypeFilterCategory;
            set
            {
                _transactionTypeFilterCategory = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }


        private void ApplyFilter()
        {
            IEnumerable<DataModel> query = _allTransactions;

            if (FromDate.HasValue)
                query = query.Where(t => t.Date >= FromDate.Value);

            if (ToDate.HasValue)
                query = query.Where(t => t.Date <= ToDate.Value);

            if (TransactionTypeFilterCategory.HasValue)
                query = query.Where(t => t.TransactionType == TransactionTypeFilterCategory.Value);

            if (SelectedFilterCategory.HasValue)
                query = query.Where(t => t.Category == SelectedFilterCategory.Value);

            Transactions = new ObservableCollection<DataModel>(query);
        }


        private void UpdateData()
        {
            if (Transactions == null || Transactions.Count == 0)
            {
                Balance = 0;
                Income = 0;
                Expense = 0;
                NumberOfIncome = 0;
                NumberOfExpense = 0;
                return;
            }

            Income = Transactions
                .Where(t => t.TransactionType == TransactionType.Income)
                .Sum(t => t.Amount);

            Expense = Transactions
                .Where(t => t.TransactionType == TransactionType.Expense)
                .Sum(t => t.Amount);

            NumberOfIncome = Transactions
                .Count(t => t.TransactionType == TransactionType.Income);

            NumberOfExpense = Transactions
                .Count(t => t.TransactionType == TransactionType.Expense);

            Balance = Income - Expense;
            if (Balance <= 0)
            {
                Balance = 0;
            }
        }

    }
}
