using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.Handler
{
    public static class EmailHandler
    {
        public static bool IsValid(string emailId)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(emailId, pattern);
        }
    }
}
