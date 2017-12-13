using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EpicorEagle.Connection;
using EpicorEagle.Model;
using WpfApp1.View;
using System.Data;
using MySql.Data.MySqlClient;
using System.Runtime.Caching;
using System.Collections;

namespace WpfApp1.View
{
    //DEAN JONES
    //JUN.23, 2017
    //Epicor.xaml.cs
    //view window code for XAML 

    //TODO
    //EPICOR (QUERY BUTTON) 
    //  (validate that it's text)
    //  (maybe use pulldown instead)(one same tab as datagrid)
    //  confirm that (MySQL) query (isSuccessful)


    /// <summary>
    /// Interaction logic for Epicor.xaml
    /// </summary>
    public partial class Epicor : Window
    {
        //CONSTANT 
        private const string CACHE_SKU_LIST = "CacheSkuList";

        //CACHE (save the SKU list)(for faster retrieval)
        //  http://www.c-sharpcorner.com/UploadFile/87b416/working-with-caching-in-C-Sharp/
        public IEnumerable GetSkuListFromCache()
        {
            //create cache object(count = 31,229)
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CACHE_SKU_LIST))
            {
                //return the cache (sku list)
                return (IEnumerable)cache.Get(CACHE_SKU_LIST);
            }
            else
            {
                //create a new cache
                IEnumerable skuList = this.GetSkuList();       //run query

                //cache rules (expiry)
                CacheItemPolicy cachePolicy = new CacheItemPolicy();
                cachePolicy.AbsoluteExpiration = DateTime.Now.AddDays(7.0);

                //store in cache
                cache.Add(CACHE_SKU_LIST, skuList, cachePolicy);

                return skuList;
            }

            //---------------
            //private const string CacheKey = "availableStocks";

            //public IEnumerable GetAvailableStocks()
            //{
            //    ObjectCache cache = MemoryCache.Default;

            //    if (cache.Contains(CacheKey))
            //        return (IEnumerable)cache.Get(CacheKey);
            //    else
            //    {
            //        IEnumerable availableStocks = this.GetDefaultStocks();

            //        // Store data in the cache    
            //        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            //        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
            //        cache.Add(CacheKey, availableStocks, cacheItemPolicy);

            //        return availableStocks;
            //    }
            //}
            //---------------
        }

        public Epicor()
        {
            InitializeComponent();

            //for window loading event
            this.Loaded += new RoutedEventHandler(EpicorWindow_Loaded);

            //load MySql grid
            //LoadDataGrid("SELECT * FROM dw_customer LIMIT 3");

            //load from textbox
            //LoadDataGridBySku("18");
            //LoadDataGridBySku(txtMySqlQuerySku.Text);

        }

        //WINDOW (LOADING) EVENT
        void EpicorWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //load combobox (sku)
            LoadComboBoxSku();
        }

        //CLICK (GO TO VIN65) WINDOW
        private void btnToVin65_Click(object sender, RoutedEventArgs e)
        {
            //create new (Window object)(Vin65.xaml.cs)(refers to CLASS, see NAME OF CLASS)
            //var main = new Epicor();
            var vin65Window = new MainWindow();
            vin65Window.Show();
            this.Close();
        }

        //LOAD DATAGRID VIEW
        private void LoadDataGrid(string query)
        {
            try
            {
                //string query = "SELECT * FROM dw_customer LIMIT 3";
                //add to grid
                dgvMySql.ItemsSource = EpicorDB.MySqlDataToDataTable(query).DefaultView;
            }
            catch (MySqlException ex2)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: MySQL Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex2.Message + "\nStack: " + ex2.StackTrace, "Error: MySQL Exception");
            }
            catch (Exception ex1)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: General Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex1.Message + "\nStack: " + ex1.StackTrace, "Error: General Exception");
            }

        }

        //BUTTON CLICK (RUN MYSQL QUERY)(BY SKU)
        private void btnMySqlQuery_Click(object sender, RoutedEventArgs e)
        {
            string sku = txtMySqlQuerySku.Text;                     //confirm this is a number
            LoadDataGridBySku(sku);
        }

        //LOAD DATAGRID VIEW (BY SKU)
        private void LoadDataGridBySku(string sku)
        {
            try
            {
                //string query = "SELECT DISTINCT in_item_number AS SKU FROM view_IN_alternate";
                //mysql query
                string query = "SELECT DISTINCT in_prime_department AS DeptNo, " +
                    "in_item_number AS SKU, " +
                    "in_item_description AS Description, " +
                    "in_item_weight AS Attr1, " +
                    "in_weight_unit AS Unit, " +
                    "in_retail_price AS Retail, " +
                    "in_quantity_on_hand AS QOH, " +
                    "in_quantity_on_order AS QOO " +
                    "FROM view_IN_alternate " +
                    //    "WHERE in_item_number=" + sku + ";";
                    "where in_sds_seq_all_stores_id=1 " +               //filters to only show one entry (need to confirm this is correct)
                    "and in_item_number=" + sku + ";";                  //input sku# here (parameterized query?)(needs to be a number)

                //data table (get data from query)
                DataTable dt = new DataTable();
                dt = EpicorDB.MySqlDataToDataTable(query);

                //add (row#) column
                DataColumn col2 = dt.Columns.Add("#", typeof(Int32));
                col2.SetOrdinal(0);          //set to left column

                //----------
                //autoincrement columns
                int index = 0;
                foreach (DataRow row in dt.Rows)
                {
                    row.SetField(col2, ++index);
                }

                //set autoincrement (new rows...)
                col2.AutoIncrement = true;
                col2.AutoIncrementSeed = ++index;
                col2.AutoIncrementStep = 1;
                col2.ReadOnly = true;       //read-only
                                            //----------

                //set table to read-only
                //dgvMySql.IsReadOnly = true;     //set the whole table (can't change checkbox column?)
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = true;      //make all columns (read-only)
                }

                //add (checkbox) column for selecting
                DataColumn col = dt.Columns.Add("Selection", typeof(bool));
                col.SetOrdinal(0);          //set to left column
                col.ReadOnly = false;       //make this column (accessible only)

                //add to grid
                //dgvMySql.ItemsSource = EpicorDB.MySqlDataToDataTable(query).DefaultView;
                dgvMySql.ItemsSource = dt.DefaultView;
            }
            catch (MySqlException ex2)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: MySQL Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex2.Message + "\nStack: " + ex2.StackTrace, "Error: MySQL Exception");
            }
            catch (Exception ex1)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: General Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex1.Message + "\nStack: " + ex1.StackTrace, "Error: General Exception");
            }

        }

        //GET SKU# LIST (QUERY)
        private List<string> GetSkuList()
        {
            DataTable dt;
            List<string> skuList = new List<string>();

            try
            {
                //string query = "SELECT DISTINCT in_item_number AS SKU FROM view_IN_alternate LIMIT 5";
                string query = "SELECT DISTINCT in_item_number AS SKU FROM view_IN_alternate";
                //cboMySku.ItemsSource = EpicorDB.MySqlDataToDataTable(query).DefaultView;

                dt = EpicorDB.MySqlDataToDataTable(query);        //save query as data table
                skuList = new List<string>();                  //pass list to combobox
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sku = dt.Rows[i]["SKU"].ToString();
                    sku = sku.Replace(" ", "");                            //remove whitespace
                    skuList.Add(sku);                                       //add each SKU to list
                }
            }
            catch (MySqlException ex2)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: MySQL Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex2.Message + "\nStack: " + ex2.StackTrace, "Error: MySQL Exception");
            }
            catch (Exception ex1)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: General Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex1.Message + "\nStack: " + ex1.StackTrace, "Error: General Exception");
            }

            return skuList;
        }

        //COMBOBOX (pulldown data)
        private void LoadComboBoxSku()
        {
            try
            {
                //get list from cache (instead of running query over and over)
                IEnumerable skuList = GetSkuListFromCache();

                ////string query = "SELECT DISTINCT in_item_number AS SKU FROM view_IN_alternate LIMIT 5";
                //string query = "SELECT DISTINCT in_item_number AS SKU FROM view_IN_alternate";
                ////cboMySku.ItemsSource = EpicorDB.MySqlDataToDataTable(query).DefaultView;

                //DataTable dt = EpicorDB.MySqlDataToDataTable(query);        //save query as data table
                //List<string> skuList = new List<string>();                  //pass list to combobox
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string sku = dt.Rows[i]["SKU"].ToString();
                //    sku = sku.Replace(" ", "");                            //remove whitespace
                //    skuList.Add(sku);                                       //add each SKU to list
                //}

                //populate combobox
                cboMySku.ItemsSource = skuList;
            }
            catch (MySqlException ex2)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: MySQL Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex2.Message + "\nStack: " + ex2.StackTrace, "Error: MySQL Exception");
            }
            catch (Exception ex1)
            {
                MessageBox.Show("There was a problem with the selection, please pick another sku#", "Error: General Exception");
                //MessageBox.Show("There was an error" + "\nMessage: " + ex1.Message + "\nStack: " + ex1.StackTrace, "Error: General Exception");
            }

        }

        //COMBOBOX (LOADING)(prepopulate with sku#'s)
        //private void cboMySku_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //load combobox (sku)
        //    //LoadComboBoxSku();
        //}

        //COMBOBOX (SKU) CHANGED
        private void cboMySku_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LINK THIS TO THE DATAGRID
            //LoadDataGridBySku(txtMySqlQuerySku.Text);
            LoadDataGridBySku(cboMySku.SelectedItem.ToString());
        }


    }
}
