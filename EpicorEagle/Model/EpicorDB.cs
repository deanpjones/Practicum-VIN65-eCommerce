using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Connection;
using MySql.Data.MySqlClient;

namespace EpicorEagle.Model
{
    public class EpicorDB
    {
        //public static DataTable GetInventoryBySku(string sku) 
        //{
        //    DataTable dt = new DataTable();
        //    //do stuff...???
        //    return dt;

        //    // https://stackoverflow.com/questions/20770438/how-to-bind-datatable-to-datagrid
        //    // C#
        //    // DataTable employeeData = CreateDataTable();
        //    // gridEmployees.DataContext = employeeData.DefaultView;
        //    // XAML
        //    //<DataGrid Name="gridEmployees" ItemsSource="{Binding}">
        //}

        //public static void GetInventory()
        //{
        //    //GridData.ItemsSource = vDs.Tables["Book"].DefaultView;
        //    //dgvMySql.ItemsSource = GetInventory();
        //}

        //QUERY TO DATAGRIDVIEW (TABLE)
        //Example:  dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView("SELECT * FROM dw_customer LIMIT 3");
        public static DataTable MySqlDataToDataTable(string myquery)
        {
            //create DataTable object to return
            DataTable t = null;

            //get connection string
            string myConnectionString = EpicorEagleConnect.GetSqlConnectionString();

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
                throw ex2;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                conn.Close();
            }

            return t;
        }
    }
}
