using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vin65WS2.Controller;
using VinInventory = vin65WS2.com.vin65.webservicesInventory;       //access the methods directly (instead of using proxy files)

namespace vin65WS2.Testing
{
    class TestInventory
    {
        //USERNAME AND PASSWORD (VIN65 API)
        static string WS_USERNAME = "DeanJonesSANDBOX";
        static string WS_PASSWORD = "willowpark";

        public static void TestSearchInventory1()
        {
            InventoryController iss = new InventoryController(WS_USERNAME, WS_PASSWORD);

            //----
            VinInventory.Response2 iss_response1 = new VinInventory.Response2();
            iss_response1 = iss.IS_SearchInventoryBySKU2("746969c");
            VinInventory.Inventory[] inventoryList = iss_response1.Inventory;

            Console.WriteLine("------");
            Console.WriteLine("INVENTORY");
            for (int i = 0; i < inventoryList.Length; i++)
            {
                Utility.Utility.DumpProperties(inventoryList[i]);
                //Console.WriteLine("SKU: " + inventoryList[i].SKU);
                //Console.WriteLine("Current Inventory: " + inventoryList[i].CurrentInventory);
            }
            Console.WriteLine("------");

        }

        public static void TestSearchInventory2()
        {
            InventoryController iss = new InventoryController(WS_USERNAME, WS_PASSWORD);

            //----
            VinInventory.Inventory iss_inventory = new VinInventory.Inventory();
            iss_inventory = iss.IS_SearchInventoryBySKU("746969c");

            Console.WriteLine("------");
            Console.WriteLine("INVENTORY");
                Utility.Utility.DumpProperties(iss_inventory);
            Console.WriteLine("------");

        }

        public static void TestAddUpdateInventory1()
        {
            InventoryController iss = new InventoryController(WS_USERNAME, WS_PASSWORD);

            //get a inventory object (before modifying...)
            VinInventory.Response2 iss_response2 = new VinInventory.Response2();
            iss_response2 = iss.IS_SearchInventoryBySKU2("746969c"); 

            //make a change
            if ((bool)iss_response2.IsSuccessful)
            {
                if(iss_response2.RecordCount == 1)
                {
                    //CHANGE THE VALUE HERE...
                    double? inventoryCount = 23d;
                    iss_response2.Inventory[0].CurrentInventory = inventoryCount;
                }
                //for (int i = 0; i < iss_response2.Inventory.Length; i++)
                //{
                //    //CHANGE THE VALUE HERE...
                //    double? inventoryCount = 999d;
                //    iss_response2.Inventory[i].CurrentInventory = inventoryCount;
                //}

            }

            //update the inventory
            VinInventory.Response1 iss_response1 = new VinInventory.Response1();
            //*****************************************************************
            iss_response1 = iss.IS_UpdateInventory(iss_response2.Inventory[0]);
            //*****************************************************************
            //print if was success
            Console.WriteLine("The INVENTORY update for {0} was a success: {1}", iss_response2.Inventory[0].SKU, iss_response1.IsSuccessful);     

        }

        public static void TestAddUpdateInventory2()
        {
            InventoryController iss = new InventoryController(WS_USERNAME, WS_PASSWORD);
            string sku = "746969c";
            double currentInventory = 44d;

            //request object
            //...
            //response object
            VinInventory.Response1 iss_response1 = new VinInventory.Response1();
            //*****************************************************************
            iss_response1 = iss.IS_AddUpdateInventoryCountBySKU(sku, currentInventory);
            //*****************************************************************
            //print if was success
            Console.WriteLine("The INVENTORY update for <sku> was a success: {0}", iss_response1.IsSuccessful);

        }

        public static void TestAddUpdateInventory3()
        {
            InventoryController iss = new InventoryController(WS_USERNAME, WS_PASSWORD);

            //request object
            //...
            //response object
            VinInventory.Response1 iss_response1a = new VinInventory.Response1();
            VinInventory.Response1 iss_response1b = new VinInventory.Response1();
            //*****************************************************************
            iss_response1a = iss.IS_AddUpdateInventoryCountBySKU("746969b", 23d);
            iss_response1b = iss.IS_AddUpdateInventoryCountBySKU("746969c", 33d);
            //*****************************************************************
            //print if was success
            Console.WriteLine("The INVENTORY update for 746969b was a success: {0}", iss_response1a.IsSuccessful);
            Console.WriteLine("The INVENTORY update for 746969c was a success: {0}", iss_response1b.IsSuccessful);

        }
    }
}
