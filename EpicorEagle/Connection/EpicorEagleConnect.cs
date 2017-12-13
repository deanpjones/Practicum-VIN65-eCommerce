using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;             //REFERENCES, ASSEMBLY, (check on System.Configuration)
using System.Data.Common;
using System.Data;

namespace EpicorEagle.Connection
{
    public class EpicorEagleConnect
    {
        //GET CONNECTION STRING (APP.CONFIG)(for Epicor Eagle MySQL database)
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EpicorEagleConnection"].ConnectionString;
        }

        //COUNT TABLES 
        public static int CountTables(string query)
        {
            int result;

            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                //************************************
                //*** STRING (query) (are in a parameter now, add string to VIEW(Program.cs) ***
                //gets all tables (~1084 tables)
                //string query = "SELECT COUNT(*) " +
                //    "FROM INFORMATION_SCHEMA.TABLES " +
                //    "WHERE TABLE_SCHEMA = 'EAGLEDW';";

                //gets all columns (~17 thousand)               
                //string query = "SELECT COUNT(*) " +
                //    "FROM INFORMATION_SCHEMA.COLUMNS " +
                //    "WHERE TABLE_SCHEMA = 'EAGLEDW';";

                //gets all rows (~10 million)
                //string query = "SELECT SUM(TABLE_ROWS) " +
                //    "FROM INFORMATION_SCHEMA.TABLES " +
                //    "WHERE TABLE_SCHEMA = 'EAGLEDW';";
                //************************************

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                //MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                result = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }

            return result;
        }

        //TEST CONNECTION 
        public static void TestSqlConnection()
        {
            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //myConnectionString = "SERVER=10.0.1.7; DATABASE=EAGLEDW; UID=dbread; PASSWORD=havemox1e";

            //print
            Console.WriteLine(myConnectionString);

            //create mysql connection object
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                //open connection
                Console.WriteLine("Epicor Eagle MySQL database...");
                conn.Open();
                Console.WriteLine("...CONNECTION SUCCESSFUL (test connection)\n");

            }
            catch (MySqlException ex2)
            {
                switch (ex2.Number)
                {
                    case 0:
                            Console.WriteLine("Cannot connect to server. Please make sure database name, username and password are correct or contact administrator");
                            break;
                    case 1042:
                            Console.WriteLine("Server path is incorrect. Contact administrator");
                            break;  
                    default:
                        {
                            Console.WriteLine("ERROR: " + 
                                "\nNumber: " + ex2.Number + 
                                "\nMessage: " + ex2.Message + 
                                "\nStack: " + ex2.StackTrace
                                );
                            break;
                        }

                }
            }
            catch (Exception ex1)
            {
                Console.WriteLine("ERROR: " +
                                "\nMessage: " + ex1.Message +
                                "\nStack: " + ex1.StackTrace
                                );
            }
            finally
            {
                conn.Close();
            }
                  
        }

        /// <summary>
        /// Write MySQL Data to Console (provide query string)
        /// </summary>
        /// <param name="myquery">Create a MySQL query string (eg. "SHOW TABLES")</param>
        /// <param name="message">A header message to go at the top of output results</param>
        /// <example>EpicorEagleConnect.PrintAllOfTableToConsole("SHOW TABLES", "All Tables Printed");</example>
        public static void PrintAllOfTableToConsole(string myquery, string message)
        {
            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //myConnectionString = "SERVER=10.0.1.7; DATABASE=EAGLEDW; UID=dbread; PASSWORD=havemox1e";

            //print
            Console.WriteLine(myConnectionString);

            //create mysql connection object
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                //open connection
                Console.WriteLine("Epicor Eagle MySQL database...");
                conn.Open();
                Console.WriteLine("...CONNECTION SUCCESSFUL\n");

                //---------------------------
                // Perform database operations
                //string selectQuery = "SELECT * FROM Customers";
                string selectQuery = myquery;
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, conn);

                //execute the query
                MySqlDataReader reader = selectCommand.ExecuteReader();

                //Console.WriteLine("ALL TABLES");
                
                Console.WriteLine(message + ", " + reader.FieldCount);
                Console.WriteLine("******************");
                //print each column row
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader[i]);
                    }
                }
                Console.WriteLine("******************");
            }
            catch (MySqlException ex2)
            {
                switch (ex2.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Please make sure database name, username and password are correct or contact administrator");
                        break;
                    case 1042:
                        Console.WriteLine("Server path is incorrect. Contact administrator");
                        break;
                    default:
                        {
                            Console.WriteLine("ERROR: " +
                                "\nNumber: " + ex2.Number +
                                "\nMessage: " + ex2.Message +
                                "\nStack: " + ex2.StackTrace
                                );
                            break;
                        }

                }
            }
            catch (Exception ex1)
            {
                Console.WriteLine("ERROR: " +
                                "\nMessage: " + ex1.Message +
                                "\nStack: " + ex1.StackTrace
                                );
            }
            finally
            {
                conn.Close();
            }

        }

        //PRINT TABLE WITH HEADERS
        public static void PrintTableWithHeaders(string myquery)
        {
            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //myConnectionString = "SERVER=10.0.1.7; DATABASE=EAGLEDW; UID=dbread; PASSWORD=havemox1e";

            //print
            Console.WriteLine(myConnectionString);

            //create mysql connection object
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                //open connection
                Console.WriteLine("Epicor Eagle MySQL database...");
                conn.Open();
                Console.WriteLine("...CONNECTION SUCCESSFUL\n");

                //---------------------------
                // Perform database operations
                //string selectQuery = "SELECT * FROM Customers";
                string selectQuery = myquery;
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, conn);

                //execute the query
                MySqlDataReader reader = selectCommand.ExecuteReader();

                //Console.WriteLine("ALL TABLES");
                Console.WriteLine("TABLE...");
                Console.WriteLine("Count: " + reader.FieldCount);

                //????????????????????????
                //print headers
                DataTable schema = null;
                schema = reader.GetSchemaTable();
                //foreach (DataRow col in schema.Rows)
                //{
                //    Console.WriteLine("ColumnName={0}", col.Field<String>("ColumnName"));
                //}


                //????????????????????????

                Console.WriteLine("******************");
                //print each column row
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //Console.WriteLine("ColumnName={i}", schema.Columns[i]);
                        Console.Write("\t" + reader[i]);
                    }
                }
                Console.WriteLine("******************");
            }
            catch (MySqlException ex2)
            {
                switch (ex2.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Please make sure database name, username and password are correct or contact administrator");
                        break;
                    case 1042:
                        Console.WriteLine("Server path is incorrect. Contact administrator");
                        break;
                    default:
                        {
                            Console.WriteLine("ERROR: " +
                                "\nNumber: " + ex2.Number +
                                "\nMessage: " + ex2.Message +
                                "\nStack: " + ex2.StackTrace
                                );
                            break;
                        }

                }
            }
            catch (Exception ex1)
            {
                Console.WriteLine("ERROR: " +
                                "\nMessage: " + ex1.Message +
                                "\nStack: " + ex1.StackTrace
                                );
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
