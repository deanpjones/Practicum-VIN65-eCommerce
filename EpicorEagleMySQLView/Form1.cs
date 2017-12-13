using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicorEagleMySQLView.Model;

namespace EpicorEagleMySQLView
{
    //DEAN JONES
    //JUN.20, 2017
    //MYSQL DATA (VIEWER UTILITY)
    //just a utility to view data in Epicor's database (used mainly to see what TABLES and COLUMNS are needed to tie into)

    //TODO
    //  get all TABLES (in pulldown)
    //  link pulldown to TABLE VIEW

    //  INVENTORY TABLE (QUERY)
    //  SELECT in_prime_department AS DeptNo, in_item_number AS SKU, in_item_description AS Description, in_item_weight AS Attr1, in_weight_unit AS Unit, in_retail_price AS Retail, in_quantity_on_hand AS QOH, in_quantity_on_order AS QOO FROM view_IN_alternate



    public partial class frmTableResults : Form
    {
        public frmTableResults()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //--------------
            //TABLE TAB
            //push data to table...
            //EpicorDB.MySqlDataToGridView("SELECT * FROM dw_customer LIMIT 3", dgvTableResults);
            dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView("SELECT * FROM dw_customer LIMIT 3");
            dgvTableResults.AutoResizeColumns();
            //dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView("SHOW TABLES");

            //data to combobox (Table Names)
            EpicorDB.MySqlDataToComboBox(cboTableNames);
            //--------------

            //--------------
            //SEARCH TAB
            //search for SKU (or other relevant tables)
            string query = @"SELECT table_name,column_name FROM information_schema.columns WHERE column_name like '%sku%'";
            dgvSearch.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgvSearch.AutoResizeColumns();
            //--------------

            //--------------
            //CUSTOM SEARCH
            //pulldown 
            EpicorDB.MySqlDataToComboBox(cboCustomQuery);
            //SELECT * FROM (SHOW TABLES);
            //string query2 = @"SELECT * FROM information_schema.columns WHERE column_name like '%sku%'";
            string query2 = @"SELECT * FROM information_schema.columns";
            dgvCustomQuery.DataSource = EpicorDB.MySqlDataToGridView(query2);
            dgvSearch.AutoResizeColumns();
            //--------------

            //--------------
            //INVENTORY TAB 
            LoadInventoryDataGridView();
            //--------------

            //--------------
            //INVENTORY (RAW) TAB 
            LoadInventoryRawDataGridView();
            //--------------
        }

        //UPDATES COMBOBOX
        private void cboTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllTables(dgvTableResults, cboTableNames);
        }

        private void txtLikeFilter_TextChanged(object sender, EventArgs e)
        {
            string likeFilter = txtLikeFilter.Text;
            //SELECT * FROM inventory WHERE color LIKE '%blue%'
            //@"SELECT table_name,column_name FROM information_schema.columns WHERE column_name like '%sku%'"
            string query = @"SELECT table_name,column_name FROM information_schema.columns WHERE column_name like '%" + likeFilter + "%'";
            dgvSearch.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgvSearch.AutoResizeColumns();
        }

        private void GetAllTables(DataGridView dgv, ComboBox cbo)
        {
            //make sure text is a number
            //int limitInt = -1;
            //if (!Validator.IsInteger(txtLimit.Text, out limitInt))
            //{
            //    limitInt = 5;
            //}

            //make sure text is a number
            string limitStr;
            if (Validator.IsIntegerRegEx(txtLimit.Text))
            {
                limitStr = txtLimit.Text;
            }
            else
            {
                limitStr = "5";
            }

            //string table = cboTableNames.SelectedItem.ToString();
            string table = cbo.SelectedItem.ToString();
            //string query = "SELECT * FROM " + table + " LIMIT " + limitInt.ToString() + ";";
            string query = "SELECT * FROM `" + table + "` LIMIT " + limitStr + ";";             //NEED BACKTICKS (`) for table name (`IN`)
            //dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgv.DataSource = EpicorDB.MySqlDataToGridView(query);
            //copy to clipboard
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgv.AutoResizeColumns();
        }

        //********************************
        //CUSTOM TAB 
        private void btnExecuteCustomQuery_Click(object sender, EventArgs e)
        {
            CustomQuery(dgvCustomQuery);
        }

        private void CustomQuery(DataGridView dgv)
        {
            //set query from textbox
            string query = txtCustomQuery.Text;

            //dgvTableResults.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgv.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgv.AutoResizeColumns();
        }

        private void cboCustomQuery_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //CUSTOM TAB 
        //********************************


        //********************************
        //INVENTORY TAB 
        private void LoadInventoryDataGridView()
        {
            string query = "SELECT DISTINCT in_prime_department AS DeptNo, " +
                "in_item_number AS SKU, " +
                "in_item_description AS Description, " +
                "in_item_weight AS Attr1, " +
                "in_weight_unit AS Unit, " +
                "in_retail_price AS Retail, " +
                "in_quantity_on_hand AS QOH, " +
                "in_quantity_on_order AS QOO " +
                "FROM view_IN_alternate " +
                "WHERE in_sds_seq_all_stores_id=1;";                //only shows first result (there are multiple lines otherwise)
            dgvInventory.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgvInventory.AutoResizeColumns();
        }

        //********************************

        //********************************
        //INVENTORY (RAW) TAB 
        private void LoadInventoryRawDataGridView()
        {
            string query = "SELECT * FROM view_IN_alternate";
            dgvInventoryRaw.DataSource = EpicorDB.MySqlDataToGridView(query);
            dgvInventoryRaw.AutoResizeColumns();
        }

        //********************************

    }
}
