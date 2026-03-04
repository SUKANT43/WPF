using Expense_Tracker.Enums;
using System;

namespace Expense_Tracker.Model
{
    public class DataModel
    {
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
    }
}