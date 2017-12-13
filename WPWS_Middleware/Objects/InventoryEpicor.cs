using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Connection;
using EpicorEagle.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace WPWS_Middleware.Objects
{
    //DEAN JONES
    //JUN.15, 2017
    //INVENTORY CLASS (Epicor)
    //middleware, with mapper to (InventoryVIN) object

    //MAPPINGS 
    //  CONSTRUCTOR (VIN65 --> Epicor)
    //  METHOD (Epicor(this) --> VIN65)
    //  ---
    //  MySQL (READ-ONLY)
    //  MYSQL --> Epicor (pull data)
    //  CSV or FLAT FILE
    //  Epicor --> MYSQL (push data)

    //PROCESS
    //  GetDataFromMySql(string sku) --> DataTable                                  //from MySQL to DataTable
    //  ConvertDataTableToObject(GetDataFromMySql(string sku)) --> THIS OBJECT      //from DataTable to Epicor object
    //  InventoryEpicorToVIN65() --> InventoryVIN65                                 //Epicor object to Vin65 object


    public class InventoryEpicor
    {
        //VARIABLES 
        private string sku;
        private string description;
        private double? retail;
        private string loc;
        private string deptNo;
        private string attr1Value;
        private string upc;
        private int? qoh;
        private int? qoo;
        private int? committedQty;
        private int? qtyAvailable;
        private string primaryVendor;
        private string mfgVendor;
        private string mfgPartNo;
        private string fineLineNo;

        //GETTERS AND SETTERS 
        public string Sku { get => sku; set => sku = RemoveWhiteSpaceInString(value); }
        public string Description { get => description; set => description = value; }
        public double? Retail { get => retail; set => retail = value; }
        public string Loc { get => loc; set => loc = value; }
        public string DeptNo { get => deptNo; set => deptNo = value; }
        public string Attr1Value { get => attr1Value; set => attr1Value = value; }
        public string Upc { get => upc; set => upc = value; }
        public int? Qoh { get => qoh; set => qoh = value; }
        public int? Qoo { get => qoo; set => qoo = value; }
        public int? CommittedQty { get => committedQty; set => committedQty = value; }
        public int? QtyAvailable { get => qtyAvailable; set => qtyAvailable = value; }
        public string PrimaryVendor { get => primaryVendor; set => primaryVendor = value; }
        public string MfgVendor { get => mfgVendor; set => mfgVendor = value; }
        public string MfgPartNo { get => mfgPartNo; set => mfgPartNo = value; }
        public string FineLineNo { get => fineLineNo; set => fineLineNo = value; }

        //CONSTRUCTOR 
        public InventoryEpicor() { }

        public InventoryEpicor(string sku)
        {
            this.sku = sku;
        }

        //CONSTRUCTOR (taking (InventoryEpicor) object to convert)
        //MAPPING (EPICOR to VIN65)
        //MAPPING (InventoryEpicor to InventoryVIN65)
        public InventoryEpicor(InventoryVIN65 inventoryVIN65)
        {
            this.sku = inventoryVIN65.Sku;
            this.description = inventoryVIN65.Title;
            this.retail = inventoryVIN65.Price;

            ////these properties (cannot be mapped)(leave blank)
            //this.loc = null;
            //this.deptNo = null;
            //this.attr1Value = null;
            //this.upc = null;
            this.qoh = (int)inventoryVIN65.CurrentInventory;
            //this.qoo = null;
            //this.committedQty = null;
            this.qtyAvailable = (int)inventoryVIN65.CurrentInventory;
            //this.primaryVendor = null;
            //this.mfgVendor = null;
            //this.mfgPartNo = null;
            //this.fineLineNo = null;
        }


        //METHOD (taking (this) object to convert)
        //MAPPING (EPICOR to VIN65)
        //MAPPING (InventoryEpicor to InventoryVIN65)
        public InventoryVIN65 InventoryEpicorToVIN65()
        {
            InventoryVIN65 iv = new InventoryVIN65(this);
            return iv;
        }

        //METHOD (DataTable => Object)
        public void ConvertDataTableToObject(string sku)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = this.GetDataFromMySql(sku);

                //map data from data table field to (THIS object)
                this.Sku = dt.Rows[0]["SKU"].ToString();
                this.Description = dt.Rows[0]["Description"].ToString();
                this.Retail = (double?)((decimal)dt.Rows[0]["Retail"]);
                this.Qoh = (int?)((decimal)dt.Rows[0]["QOH"]);

                //private string sku;
                //private string description;
                //private double? retail;
                //private int? qoh;
            }
            catch (MySqlException ex2)
            {
                throw ex2;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }

        }

        //METHOD (MySQL => DataTable)
        public DataTable GetDataFromMySql(string sku)
        {
            try
            {
                //mysql query
                string query = "SELECT DISTINCT in_item_number AS SKU, " +
                    "in_item_description AS Description, " +
                    //"in_item_weight AS Attr1, " +
                    //"in_weight_unit AS Unit, " +
                    "in_retail_price AS Retail, " +
                    "in_quantity_on_hand AS QOH " +
                    //"in_quantity_on_order AS QOO " +
                    "FROM view_IN_alternate " +
                    //    "WHERE in_item_number=" + sku + ";";
                    "WHERE in_sds_seq_all_stores_id=1 " +               //filters to only show one entry (need to confirm this is correct)
                    "AND in_item_number=" + sku + ";";                  //input sku# here (parameterized query?)(needs to be a number)

                //data table (get data from query)
                DataTable dt = new DataTable();

                //get MySQL data into table
                dt = EpicorDB.MySqlDataToDataTable(query);

                //set data type for data table (cannot change the type after it's filled)
                //dt.Columns[0].DataType = typeof(System.String);     //sku (string)
                //dt.Columns[1].DataType = typeof(System.String);     //description (string)
                //dt.Columns[2].DataType = typeof(System.Double);     //retail (double?)
                //dt.Columns[2].AllowDBNull = true;                   //allow nulls
                //dt.Columns[3].DataType = typeof(System.Int32);      //qoh (int?)
                //dt.Columns[3].AllowDBNull = true;                   //allow nulls

                return dt;
            }
            catch (MySqlException ex2)
            {
                throw ex2;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            
        }

        //TOSTRING (override)
        public override string ToString()
        {
            return 
                sku + "' " +
                description + ", " +
                retail + ", " +
                loc + ", " +
                deptNo + ", " +
                attr1Value + ", " +
                upc + ", " +
                qoh + ", " +
                qoo + ", " +
                committedQty + ", " +
                qtyAvailable + ", " +
                primaryVendor + ", " +
                mfgVendor + ", " +
                mfgPartNo + ", " +
                fineLineNo;
        }

        //REMOVE WHITESPACE 
        private string RemoveWhiteSpaceInString(string mystring)
        {
            mystring = mystring.Replace(" ", "");
            return mystring;
        }


        //--------------------------------------------------------------------------------------------
        //MAPPING (see InventoryVIN65 class)
        //--------------------------------------------------------------------------------------------
    }
}
