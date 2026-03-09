using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Model
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public UserModel User { get; set; }
    }
}
