using System.Collections.Generic;

namespace Expense_Tracker.Model
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<DataModel> History { get; set; } = new List<DataModel>();
    }
}