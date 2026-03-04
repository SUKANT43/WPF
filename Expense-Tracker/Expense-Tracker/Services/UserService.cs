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
    public static class UserService
    {
        private static readonly string _folderPath = @"C:\ExpenseTracker";

        static UserService()
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        private static string GetFilePath(string email)
        {
            string safeEmail = email.Replace("@", "_at_").Replace(".", "_");
            return Path.Combine(_folderPath, safeEmail + ".json");
        }

        public static bool UserExists(string email)
        {
            string path = GetFilePath(email);
            return File.Exists(path);
        }


        public static void SaveUser(UserModel user)
        {
            string path = GetFilePath(user.Email);
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static UserModel GetUser(string email)
        {
            string path = GetFilePath(email);
            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserModel>(json);
        }

        public static LoginResult LoginUser(string email, string password)
        {
            if (!UserExists(email))
            {
                return new LoginResult
                {
                    IsSuccess = false,
                    Message = "User does not exist. Please register first."
                };
            }

            UserModel user = GetUser(email);

            if (user.Password != password)
            {
                return new LoginResult
                {
                    IsSuccess = false,
                    Message = "Invalid password."
                };
            }

            return new LoginResult
            {
                IsSuccess = true,
                Message = "Login successful",
                User = user
            };
        }
    }
}
