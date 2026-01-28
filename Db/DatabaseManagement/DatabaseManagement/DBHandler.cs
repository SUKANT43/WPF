using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
using GoLibrary;
using MySQLDatabase;
using System.Collections;
namespace DatabaseManagement
{
    class DBHandler
    {
        public DBHandler() { }

        public DatabaseManager DatabaseCommunicator { get; set; }

        public DBHandler(string hostName, string userName, string password, string dbName,
            string engine = "InnoDB", string characterSet = "latin1", string collation = "latin1_swedish_ci")
        {
            DatabaseCommunicator = new MySqlHandler(hostName, userName, password, dbName)
            {
                StorageEngine = engine
            };
        }

        public BooleanMsg Initialized { get; private set; }
        public BooleanMsg InitializeDB()
        {
            if (Initialized) return true;
            DatabaseCommunicator.CheckAndCreateDatabase();
            string init = "";

            if (!DatabaseCommunicator.IsConnected)
            {
                DatabaseCommunicator.Connect().OnFailure(res => { init += res; });
            }
            if (init.Length > 0)
            {
                return new BooleanMsg(false) {Message=init };
            }
            Initialized = new BooleanMsg(init.Length <= 0, init);
            return Initialized;

        }

        public BooleanMsg CreateTable(string tableName, ColumnDetails[] columnDetails)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            BooleanMsg created = DatabaseCommunicator.TableExists(tableName);

            if (created)
            {
                return new BooleanMsg() { Message = "Table already exist" };
            }
            created = DatabaseCommunicator.CreateTable(tableName, columnDetails);
            return new BooleanMsg(true) { Message="Table created"};
        }

        public BooleanMsg ExecuteQuery(string query)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            BooleanMsg bm= DatabaseCommunicator.ExecuteQuery(query);

            if (!bm)
            {
                return new BooleanMsg(false) { Message ="Query not executed"};
            }

            return new BooleanMsg(true) { Message = "Query executed" };

        }

        public BooleanMsg AddData(string tableName, ParameterData[] data)
        {

            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(tableName))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }

            BooleanMsg addData = DatabaseCommunicator.InsertData(tableName, data);

            return addData;

        }

        public BooleanMsg UpdateData(string tableName,string condition, ParameterData[] data)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(tableName))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }

            BooleanMsg updateData = DatabaseCommunicator.UpdateData(tableName, condition, data);

            return updateData;
        }

        public BooleanMsg DeleteData(string tableName,string condition)
        {
            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(tableName))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }

            BooleanMsg deleteData = DatabaseCommunicator.DeleteData(tableName, condition);
            return deleteData;
        }


        public BooleanMsg<List<object>> FetchColumn(string table,string columnName,string condition)
        {

            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(table))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }
           BooleanMsg<List<object>> data= DatabaseCommunicator.FetchColumn(table,columnName,condition);
            return data;
        }

        public BooleanMsg<Dictionary<string, List<object>>> FetchData(string table, string condition)
        {

            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(table))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }
            BooleanMsg <Dictionary< string, List<object>>> data= DatabaseCommunicator.FetchData(table,condition);
            return data;
        }

        public BooleanMsg<object> FetchSingleData(string table, string columnName, string condition)
        {

            BooleanMsg msg = InitializeDB();
            if (!msg)
            {
                return new BooleanMsg(false) { Message = "Db not connected" };
            }

            if (!DatabaseCommunicator.TableExists(table))
            {
                return new BooleanMsg(false) { Message = "Table not exist" };
            }
            BooleanMsg<object> data = DatabaseCommunicator.FetchSingleData(table, columnName, condition);
            return data;
        }

    }
}
