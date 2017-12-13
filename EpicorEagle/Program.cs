using System;
using EpicorEagle.Connection;
using EpicorEagle.Utility;

namespace EpicorEagle
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------
            //TEST CSV DETAIL (OBJECT)
            Testing.TestCsvDetailObject.MyTestCsvDetailObject();
            //-----------------
            //VALIDATION TEST
            //Testing.TestCsvHeaderValidation.MyTestCsvHeaderValidation();
            //-----------------
            //TEST CSV HEADER (OBJECT)
            //Testing.TestCsvHeaderObject.MyTestCsvHeaderObject();
            //-----------------
            //TEST CSV FORMATS
            //Testing.TestCSV.Test1();
            //-----------------

            //?????????
            //SqlSearch.MySearch();
            //?????????
            //Console.WriteLine("Search...");
            //SqlSearch.SearchText("sku");
            //Console.WriteLine("..end search");

            //******************************************
            //******************************************
            //BACKUP EPICOR EAGLE (TO FILE)(*.SQL)
            //(*** COMMENT OUT, so this doesn't run all the time ***)
            //   BackupEpicorEagleDb.BackupMySqlDatabaseAll();
            //BackupEpicorEagleDb.BackupMySqlDatabaseByTable();
            //Console.WriteLine("backup...");
            //******************************************
            //******************************************

            //Console.WriteLine("************************");
            //Console.WriteLine(EpicorEagleConnect.GetSqlConnectionString());
            //Console.WriteLine("************************");

            //test connection           
            //EpicorEagleConnect.TestSqlConnection();

            //test TABLE NAMES
            //EpicorEagleConnect.PrintAllOfTableToConsole("SHOW TABLES", "All Tables Printed");
            ////count tables
            //string query = "SELECT COUNT(*) " +
            //    "FROM INFORMATION_SCHEMA.TABLES " +
            //    "WHERE TABLE_SCHEMA = 'EAGLEDW';";
            //Console.WriteLine("Count: " + EpicorEagleConnect.CountTables(query));

            //COLUMN INFO
            //EpicorEagleConnect.PrintAllOfTableToConsole("DESCRIBE dw_customer", "Table Column Info");
            //EpicorEagleConnect.PrintAllOfTableToConsole("SHOW COLUMNS FROM dw_customer", "Table Column Info");

            //COLUMN NAMES (only)
            //string query = "SELECT `COLUMN_NAME` " +
            //    "FROM `INFORMATION_SCHEMA`.`COLUMNS` " +
            //    "WHERE `TABLE_NAME`= 'dw_customer'";
            //    //"WHERE `TABLE_SCHEMA`= 'EAGLEDW' " +
            //    //"AND `TABLE_NAME`= 'dw_customer';";
            //EpicorEagleConnect.PrintAllOfTableToConsole(query, "Column Names");







            //?????
            //EpicorEagleConnect.PrintAllOfTableToConsole("SHOW DATABASES", "...");

            //EpicorEagleConnect.PrintTableWithHeaders("SELECT * FROM dw_customer LIMIT 1");
            //EpicorEagleConnect.PrintAllOfTableToConsole("SELECT * FROM SSH", "All Tables Printed");

            //...
            //EpicorEagleConnect.PrintAllOfTableToConsole("SELECT * FROM view_customer", "See in table");

            //hold the console window open
            Console.Read(); 
        }


    }


}
