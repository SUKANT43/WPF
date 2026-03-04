using Expense_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Session
{
    public static class UserSession
    {
        public static UserModel CurrentUser { get; set; }
    }
}
