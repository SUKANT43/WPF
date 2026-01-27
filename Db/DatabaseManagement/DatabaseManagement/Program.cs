using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
using GoLibrary;
using System.Globalization;
namespace DatabaseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            DBHandler db= new DBHandler(
               "localhost",
               "root",
               "",
               "testdb"
            );

            BooleanMsg msg = db.InitializeDB();


            //    BooleanMsg b = db.CreateTable("testDB", new ColumnDetails[] {
            //         new ColumnDetails("ID"){ DataType = BaseDatatypes.SMALLINT, TypeOfIndex = IndexType.PrimaryKey, IsAutoIncrement = true},
            //         new ColumnDetails("ProfileName"){ DataType = BaseDatatypes.VARCHAR,  Length = 249},
            //         new ColumnDetails("CreatedBy"){ DataType = BaseDatatypes.VARCHAR, Length = 125},
            //         new ColumnDetails("CreatedTime"){ DataType =  BaseDatatypes.TIMESTAMP, DefaultMode = DefaultType.Current_Timestamp}
            //     });

            //    Console.WriteLine(b.Message);


            //BooleanMsg ms = db.ExecuteQuery("RENAME TABLE testDB TO testTable;");


            ////Console.WriteLine(ms.Message);

            //for (int i = 1; i <= 20; i++)
            //{
            //    BooleanMsg add = db.AddData(
            //        "testTable",
            //        new ParameterData[]
            //        {
            //new ParameterData("ProfileName", $"sukant_{i}"),
            //new ParameterData("CreatedBy", "sukant"),
            //new ParameterData(
            //    "CreatedTime",
            //    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            //)
            //        }
            //    );

            //    if (!add)
            //    {
            //        Console.WriteLine($"Insert failed at record {i}: {add.Message}");
            //        break;
            //    }
            //}

            //Console.WriteLine(add.Message);


            //string condition = $"{"ProfileName"}={"sukant"}";

            //BooleanMsg update = db.UpdateData("testTable", condition, new ParameterData[] { new ParameterData("CreatedBy", "ilakiya") });

            //Console.WriteLine(update.Message);


            //BooleanMsg delete = db.DeleteData("testTable", "ProfileName='sukant_1'");

            //Console.WriteLine(delete.Message);

            BooleanMsg<List<object>> result =
                db.FetchColumn("testTable", "ProfileName", "");

            if (!result)
            {
                Console.WriteLine("Error: " + result.Message);
                return;
            }

            var d = result.Value;

            foreach (var row in d)
            {
                Console.WriteLine(row);
            }


            BooleanMsg<Dictionary<string, List<object>>> data = db.FetchData("testTable", "");

            if (!data)
            {
                Console.WriteLine("Error: " + data.Message);
                return;
            }

            var table = data.Value;

            if (table == null || table.Count == 0)
            {
                Console.WriteLine("No records found");
                return;
            }

            int rowCount = table.First().Value.Count;

            foreach (var column in table.Keys)
            {
                Console.Write(column + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < rowCount; i++)
            {
                foreach (var column in table)
                {
                    Console.Write(column.Value[i] + "\t");
                }
                Console.WriteLine();
            }


            BooleanMsg<object> singleData =
                db.FetchSingleData("testTable", "ProfileName", "ProfileName='sukant_2'");

         
                Console.WriteLine("Error: " + singleData.Value);
             
            Console.ReadLine();


        }
    }
}
