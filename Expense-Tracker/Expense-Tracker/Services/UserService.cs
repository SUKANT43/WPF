using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Expense_Tracker.Model;

namespace Expense_Tracker.Services
{
    class UserService
    {
        private readonly string _folderPath = @"C:\ExpenseTracker";

        public UserService()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        private string GetFilePath(string email)
        {
            string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
            return Path.Combine(_folderPath, safeEmail + ".json");
        }

        public bool UserExists(string email)
        {
            string path = GetFilePath(email);
            return File.Exists(path);
        }


        public void SaveUser(UserModel user)
        {
            string path = GetFilePath(user.Email);
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public UserModel GetUser(string email)
        {
            string path = GetFilePath(email);
            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserModel>(json);

        }
    }
}
