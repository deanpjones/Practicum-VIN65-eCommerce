using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpicorEagleMySQLView.Model
{
    public class EpicorDB
    {
        //GET CONNECTION STRING (APP.CONFIG)(for Epicor Eagle MySQL database)
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EpicorEagleConnection"].ConnectionString;
        }       

        //COMBOBOX TABLE NAMES
        public static void MySqlDataToComboBox(ComboBox cbo)
        {
            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SHOW TABLES", conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        cbo.Items.Add(reader[i].ToString());
                    }
                }

                reader.Close();
            }

        }

        //QUERY TO DATAGRIDVIEW (TABLE)
        //Example       dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView("SELECT * FROM dw_customer LIMIT 3");
        public static DataTable MySqlDataToGridView(string myquery)
        {
            //create DataTable object to return
            DataTable t = null;

            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion
            //"Allow Zero Datetime=True;";

            //create mysql connection object
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                //open connection
                conn.Open();

                //using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT * FROM dw_customer LIMIT 3", conn))
                using (MySqlDataAdapter a = new MySqlDataAdapter(myquery, conn))
                {
                    // Use DataAdapter to fill DataTable
                    t = new DataTable();
                    a.Fill(t);

                    // put in table
                    //dgv.DataSource = t;
                }

            }
            catch (MySqlException ex2)
            {
                switch (ex2.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Please make sure database name, username and password are correct or contact administrator");
                        break;
                    case 1042:
                        MessageBox.Show("Server path is incorrect. Contact administrator");
                        break;
                    default:
                        {
                            MessageBox.Show("ERROR: " +
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
                MessageBox.Show("ERROR: " +
                                "\nMessage: " + ex1.Message +
                                "\nStack: " + ex1.StackTrace
                                );
            }
            finally
            {
                conn.Close();               
            }

            return t;
        }

        //QUERY TO DATAGRIDVIEW (TABLE)
        public static void MySqlDataToGridView(string myquery, DataGridView dgv)
        {
            //get connection string
            string myConnectionString = GetSqlConnectionString();
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e; " +
            //    "ConvertZeroDateTime=True;";            //FIX, for date/time error conversion
            //"Allow Zero Datetime=True;";

            //create mysql connection object
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                //open connection
                conn.Open();

                //using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT * FROM dw_customer LIMIT 3", conn))
                using (MySqlDataAdapter a = new MySqlDataAdapter(myquery, conn))
                {
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);

                    // put in table
                    dgv.DataSource = t;
                }

            }
            catch (MySqlException ex2)
            {
                switch (ex2.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Please make sure database name, username and password are correct or contact administrator");
                        break;
                    case 1042:
                        MessageBox.Show("Server path is incorrect. Contact administrator");
                        break;
                    default:
                        {
                            MessageBox.Show("ERROR: " +
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
                MessageBox.Show("ERROR: " +
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
