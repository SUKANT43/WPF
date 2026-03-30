using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
