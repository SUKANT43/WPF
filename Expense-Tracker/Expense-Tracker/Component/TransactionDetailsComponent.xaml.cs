using Expense_Tracker.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Expense_Tracker.Component
{
    public partial class TransactionDetailsComponent : UserControl
    {
        public TransactionDetailsComponent()
        {
            InitializeComponent();
        }

        public DateTime ExpenseDate
        {
            get => (DateTime)GetValue(ExpenseDateProperty);
            set => SetValue(ExpenseDateProperty, value);
        }

        public static readonly DependencyProperty ExpenseDateProperty =
            DependencyProperty.Register(
                nameof(ExpenseDate),
                typeof(DateTime),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata(DateTime.Now));



        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(
                nameof(Description),
                typeof(string),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata(""));



        public double Amount
        {
            get => (double)GetValue(AmountProperty);
            set => SetValue(AmountProperty, value);
        }

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register(
                nameof(Amount),
                typeof(double),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata(0d));



        public string Day
        {
            get => (string)GetValue(DayProperty);
            set => SetValue(DayProperty, value);
        }

        public static readonly DependencyProperty DayProperty =
            DependencyProperty.Register(
                nameof(Day),
                typeof(string),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata("Mo"));



        public Category CategoryType
        {
            get => (Category)GetValue(CategoryTypeProperty);
            set => SetValue(CategoryTypeProperty, value);
        }

        public static readonly DependencyProperty CategoryTypeProperty =
            DependencyProperty.Register(
                nameof(CategoryType),
                typeof(Category),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata(Category.Food));



        public TransactionType Type
        {
            get => (TransactionType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(
                nameof(Type),
                typeof(TransactionType),
                typeof(TransactionDetailsComponent),
                new PropertyMetadata(TransactionType.Income));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(TransactionDetailsComponent));
    }
}