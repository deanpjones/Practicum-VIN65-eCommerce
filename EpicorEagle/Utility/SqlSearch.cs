using EpicorEagle.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Utility
{
    public static class SqlSearch
    {

        public static void MySearch()
        {
            string myConnectionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string firstSql = null;
            string secondSql = null;

            //get connection string
            myConnectionString = EpicorEagleConnect.GetSqlConnectionString();
            //connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            //myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion
            firstSql = "SELECT * FROM dw_item";
            secondSql = "SELECT * FROM ADR LIMIT 1";
            //firstSql = "SELECT * FROM ADR LIMIT 3";
            //secondSql = "SELECT * FROM INXCAT LIMIT 3";
            connection = new MySqlConnection(myConnectionString);

            try
            {
                connection.Open();

                command = new MySqlCommand(firstSql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "First Table");

                adapter.SelectCommand.CommandText = secondSql;
                adapter.Fill(ds, "Second Table");

                //******************************************
                //UNCOMMENT TO WRITE (note, large database create large XML files, do one table at a time...)
                //write to file
                //string filepath = @"C:\_dump\file.xml";
                //ds.WriteXml(filepath);
                //******************************************

                adapter.Dispose();
                command.Dispose();
                connection.Close();

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    foreach (DataColumn column in ds.Tables[1].Columns)
                    {                       
                        var result = row[column].ToString();
                        var colName = column.Caption;

                        //if (result == "16.99")
                        {
                            var index = ds.Tables[1].Rows.IndexOf(row);
                            Console.WriteLine("Row: " + index + ", Column: " + colName + ", Value: " + result);
                        }
                    }
                }              
                Console.WriteLine("...end of search");

                //retrieve first table data 
                //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //{          

                //    //Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                //}
                //retrieve second table data 
                //for (i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                //{
                //    //Console.WriteLine(ds.Tables[1].Rows[i].ItemArray[0] + " -- " + ds.Tables[1].Rows[i].ItemArray[1]);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }

        }

        //  https://stackoverflow.com/questions/15210267/is-there-a-way-to-search-the-fields-of-all-tables-at-once-in-sql-server-ce
        public static void SearchText(string searchText)
        {
            //get connection string
            string myConnectionString = EpicorEagleConnect.GetSqlConnectionString();
            //string connStr = "Data Source=Northwind40.sdf;Persist Security Info=False;";
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT c.TABLE_NAME, c.COLUMN_NAME ";
                sql += "FROM   INFORMATION_SCHEMA.COLUMNS AS c ";
                sql += "INNER JOIN INFORMATION_SCHEMA.Tables AS t ON t.TABLE_NAME = c.TABLE_NAME ";
                sql += "WHERE  (c.DATA_TYPE IN ('char', 'nchar', 'varchar', 'nvarchar', 'text', 'ntext')) AND (t.TABLE_TYPE = 'TABLE') ";

                //SqlCeDataAdapter da = new SqlCeDataAdapter(sql, connStr);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, myConnectionString);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    string dynSQL = "SELECT [" + dr["COLUMN_NAME"] + "]";
                    dynSQL += " FROM [" + dr["TABLE_NAME"] + "]";
                    dynSQL += " WHERE [" + dr["COLUMN_NAME"] + "] LIKE '%" + searchText + "%'";

                    DataTable result = new DataTable();
                    da = new MySqlDataAdapter(dynSQL, myConnectionString);
                    da.Fill(result);
                    foreach (DataRow r in result.Rows)
                    {
                        Console.WriteLine("Table Name: " + dr["TABLE_NAME"]);
                        Console.WriteLine("Column Name: " + dr["COLUMN_NAME"]);
                        Console.WriteLine("Value: " + r[0]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }


        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlServerCe;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SQLCESearch
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            SearchText("Nancy");
//            Console.ReadKey();
//        }

//        private static void SearchText(string searchText)
//        {
//            string connStr = "Data Source=Northwind40.sdf;Persist Security Info=False;";
//            DataTable dt = new DataTable();
//            try
//            {
//                string sql = "SELECT c.TABLE_NAME, c.COLUMN_NAME ";
//                sql += "FROM   INFORMATION_SCHEMA.COLUMNS AS c ";
//                sql += "INNER JOIN INFORMATION_SCHEMA.Tables AS t ON t.TABLE_NAME = c.TABLE_NAME ";
//                sql += "WHERE  (c.DATA_TYPE IN ('char', 'nchar', 'varchar', 'nvarchar', 'text', 'ntext')) AND (t.TABLE_TYPE = 'TABLE') ";

//                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, connStr);
//                da.Fill(dt);

//                foreach (DataRow dr in dt.Rows)
//                {
//                    string dynSQL = "SELECT [" + dr["COLUMN_NAME"] + "]";
//                    dynSQL += " FROM [" + dr["TABLE_NAME"] + "]";
//                    dynSQL += " WHERE [" + dr["COLUMN_NAME"] + "] LIKE '%" + searchText + "%'";

//                    DataTable result = new DataTable();
//                    da = new SqlCeDataAdapter(dynSQL, connStr);
//                    da.Fill(result);
//                    foreach (DataRow r in result.Rows)
//                    {
//                        Console.WriteLine("Table Name: " + dr["TABLE_NAME"]);
//                        Console.WriteLine("Column Name: " + dr["COLUMN_NAME"]);
//                        Console.WriteLine("Value: " + r[0]);
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.Write(e.Message);
//            }


//        }
//    }
//}
