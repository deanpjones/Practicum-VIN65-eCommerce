using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vin65WS.Controller;               
using VinInventory = vin65WS2.com.vin65.webservicesInventory;       //access the methods directly (instead of using proxy files)


namespace vin65WS2.Controller
{
    //DEAN JONES
    //JUN.27, 2017
    //InventoryController.cs
    //handles all the METHODS for making calls related to INVENTORY (# of products)

    //SUPPORTING FILES 
    //  Proxy/InventoryServiceService.cs (proxy class)(generated from wsdl.exe)

    class InventoryController
    {
        //OBJECTS
        MyConnection conn;                  //to connect with username and password
        VinInventory.InventoryServiceService iss;     //connect to (Inventory Service)
        //------
        //SEARCH INVENTORY      
        VinInventory.Request2 iss_request2;
        private VinInventory.Response2 iss_response2;
        //------
        //UPDATE INVENTORY      
        VinInventory.Request1 iss_request1;
        private VinInventory.Response1 iss_response1;
        //------

        //CONSTRUCTOR
        public InventoryController(string username, string password)
        {
            //INSTANTIATE OBJECTS
            conn = new MyConnection(username, password);    //Establish a connection when an object is created
            iss = new VinInventory.InventoryServiceService();         //create INVENTORY SERVICES object

            //--------------
            //SEARCH INVENTORY
            iss_request2 = new VinInventory.Request2();                 //create REQUEST object
            iss_request2.Security = new VinInventory.Security();        //Security settings for connection (to VIN65 web service)
            iss_response2 = new VinInventory.Response2();               //create RESPONSE object (array of Products[...])

            //SET USERNAME and PASSWORD
            iss_request2.Security.Username = conn.Ws_Username;        //set global username
            //ps_request.Security.Username = "DeanJonesSANDBOX";
            iss_request2.Security.Password = conn.Ws_Password;        //set global password
            //ps_request.Security.Password = "willowpark";
            //--------------

            //--------------
            //UPDATE INVENTORY
            iss_request1 = new VinInventory.Request1();                 //create REQUEST object
            iss_request1.Security = new VinInventory.Security();        //Security settings for connection (to VIN65 web service)
            iss_response1 = new VinInventory.Response1();               //create RESPONSE object (array of Products[...])

            //SET USERNAME and PASSWORD
            iss_request1.Security.Username = conn.Ws_Username;        //set global username
            //ps_request.Security.Username = "DeanJonesSANDBOX";
            iss_request1.Security.Password = conn.Ws_Password;        //set global password
            //ps_request.Security.Password = "willowpark";
            //--------------
        }

        //GETTERS AND SETTERS
        public VinInventory.Response2 Iss_response2 { get => iss_response2; }
        public VinInventory.Response1 Iss_response1 { get => iss_response1; }


        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //METHOD (UPDATE)(COUNT BY SKU)(INVENTORY object)(returns Response2)
        public VinInventory.Response1 IS_AddUpdateInventoryCountBySKU(string sku, double myCurrentInventory)
        {         
            //get a inventory object (before modifying...)
            iss_response2 = this.IS_SearchInventoryBySKU2(sku);

            //make a change
            if ((bool)iss_response2.IsSuccessful)
            {
                if (iss_response2.RecordCount == 1)
                {
                    //CHANGE THE VALUE HERE...
                    //***************************************************************
                    iss_response2.Inventory[0].CurrentInventory = myCurrentInventory;
                    //***************************************************************
                }

            }

            //update the inventory
            //*****************************************************************
            iss_response1 = this.IS_UpdateInventory(iss_response2.Inventory[0]);
            //*****************************************************************

            return iss_response1;

        }

        //METHOD (ADD/UPDATE)(INVENTORY object)(returns Response2)
        public VinInventory.Response1 IS_UpdateInventory(VinInventory.Inventory myinventory)
        {
            //*** see constructor for instantiated objects... ***

            //MODE (ps_request2.Mode)
            //'CreateAttributes' (some properties) will be created on the fly. 
            //'Strict' (some properties) must exist or add/update will error.
            //< ErrorCode xsi: type = "xsd:string" > InvalidMode </ ErrorCode >
            //< ErrorMessage xsi: type = "xsd:string" > Mode must be one of Strict,CreateAttributes </ ErrorMessage >
            //
            //WebsiteID, ProductID, Region (in Strict Mode...)(if these are removed it will create object...)

            //check if PRODUCT already exists...(ProductID...)
            //add new product OR update existing...?
            //

            try
            {
                //set mode
                iss_request1.Mode = "Strict";               //'Strict' (some properties) must exist or add/update will error.
                //**********************************
                //add (Inventory object) to request
                iss_request1.Inventory = myinventory;       //need to provide an (Inventory object)(use GetMethod...)
                //**********************************
                //ps_request2.Security                      //already set in constructor

                //************************************************
                iss_response1 = iss.UpdateInventory(iss_request1);
                //************************************************
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iss_response1;
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //METHOD (SEARCH)(INVENTORY object)(returns Inventory)
        //returns a list of inventory (should only be one, one SKU)
        public VinInventory.Inventory IS_SearchInventoryBySKU(string sku)
        {
            //*** see constructor for instantiated objects... ***

            //Create a PRODUCT 
            VinInventory.Inventory inventoryList = new VinInventory.Inventory();

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                iss_request2.SKU = sku;
                //********************************************
                iss_response2 = iss.SearchInventory(iss_request2);
                //********************************************

                //TEST IF THE QUERY WAS SUCCESSFUL
                if ((bool)iss_response2.IsSuccessful)
                {
                    if(iss_response2.RecordCount == 1)
                    {
                        inventoryList = iss_response2.Inventory[0];
                    }
                    else if(iss_response2.RecordCount > 1)  //shouldn't equal more than one (with one sku)
                    {
                        inventoryList = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inventoryList;
        }


        //METHOD (SEARCH)(INVENTORY object)(returns Response2)
        //(same as PS_SearchInventoryBySKU, but RETURN OBJECT is ONE LEVEL HIGHER)(gives IsSuccessful, Errors, RecordCount properties)
        public VinInventory.Response2 IS_SearchInventoryBySKU2(string sku)
        {
            //*** see constructor for instantiated objects... ***

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                iss_request2.SKU = sku;
                //********************************************
                iss_response2 = iss.SearchInventory(iss_request2);
                //********************************************
                //System.InvalidOperationException: 'There is an error in XML document (5, 6).'
            }
            catch (InvalidOperationException ex1)
            {
                //Console.WriteLine(iss_response2.Errors);
                throw ex1;
                //Console.WriteLine("\nMessage: " + ex1.Message + "\n\nStackTrace: " + ex1.StackTrace + "\n\nSource: " + ex1.Source + 
                //    "\n\nInnerException" + ex1.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
                //Console.WriteLine("\nMessage: " + ex.Message + "\n\nStackTrace: " + ex.StackTrace + "\n\nSource: " + ex.Source +
                //    "\n\nInnerException" + ex.InnerException);
            }

            return iss_response2;
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************
    }
}
