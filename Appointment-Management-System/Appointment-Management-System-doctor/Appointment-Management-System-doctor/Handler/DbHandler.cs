using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.Handler
{
    public class DBHandler
    {
        public DBHandler() { }

        public DatabaseManager DataBaseCommunicator { get; set; }

        public DBHandler(string hostName= "localhost", string userName= "root", string password= "Lucid123", string dbName= "hospital",
            string engine = "InnoDB", string characterSet = "latin1", string collation = "latin1_swedish_ci")
        {
            DataBaseCommunicator = new MySqlHandler(hostName, userName, password, dbName)
            {
                StorageEngine=engine
            };
        }

    }
}
