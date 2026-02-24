using Expense_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Model
{
    public class DataModel
    {
        public TransactionType TransactionType;
        public double Amount;
        public string Description;
        public Category Category;
        public DateTime Date;
    }

}
