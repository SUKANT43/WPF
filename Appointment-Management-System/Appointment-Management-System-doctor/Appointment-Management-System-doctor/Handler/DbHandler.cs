using Appointment_Management_System_doctor.Model;
using DatabaseLibrary;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_doctor.Handler
{
    public  class DBHandler
    {

        public static DatabaseManager DataBaseCommunicator { get; set; }

        public DBHandler(string hostName = "localhost", string userName = "root", string password = "Lucid123", string dbName = "hospital",
            string engine = "InnoDB", string characterSet = "latin1", string collation = "latin1_swedish_ci")
        {
            DataBaseCommunicator = new MySqlHandler(hostName, userName, password, dbName)
            {
                StorageEngine = engine
            };
        }

        public static BooleanMsg Initialized { get; private set; }
        public static BooleanMsg InitializeDB()
        {
            if (Initialized) return true;

            DataBaseCommunicator.CheckAndCreateDatabase();
            string init = "";
            if (!DataBaseCommunicator.IsConnected)
            {
                DataBaseCommunicator.Connect().OnFailure(res => { init += res; });
            }

            if (init.Length > 0)
            {
                return new BooleanMsg(false) { Message = init };
            }

            Initialized = new BooleanMsg(init.Length <= 0, init);
            return Initialized;

        }

        public static BooleanMsg CreateTable(string tableName, ColumnDetails[] columnDetails)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            BooleanMsg created = DataBaseCommunicator.TableExists(tableName);

            if (created)
            {
                return new BooleanMsg() { Message = "Table already exist" };
            }

            created = DataBaseCommunicator.CreateTable(tableName, columnDetails);
            return new BooleanMsg(true) { Message = "Table created" };
        }

        public static BooleanMsg IsTableExist(string tableName)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }
            BooleanMsg created = DataBaseCommunicator.TableExists(tableName);
            return created;
        }

        //public BooleanMsg ExecuteQuery(string query)
        //{
        //    BooleanMsg msg = InitializeDB();
        //    if (!msg)
        //    {
        //        return new BooleanMsg(false) { Message = "Db not connected" };
        //    }

        //    BooleanMsg bm = DataBaseCommunicator.ExecuteQuery(query);

        //    if (!bm)
        //    {
        //        return new BooleanMsg(false) { Message = "Query not executed" };
        //    }
        //    return new BooleanMsg(true) { Message = "Query executed" };
        //}

        public static BooleanMsg<object> GetSingleData(string table,string columnName,string condition)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DataBaseCommunicator.TableExists(table))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }
            BooleanMsg<object> data = DataBaseCommunicator.FetchSingleData(table,columnName, condition);
            return data;
        }

        public static BooleanMsg AddData(string tableName, ParameterData[] data)
        {

            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DataBaseCommunicator.TableExists(tableName))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }

            BooleanMsg addData = DataBaseCommunicator.InsertData(tableName, data);

            return addData;

        }


    }
}
