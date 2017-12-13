using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using vin65WS2.Controller;
using vin65WS2.Testing;

namespace vin65WS2
{
    //DEAN JONES
    //MAY 26, 2017
    //VIN65 WEB SERVICE CLIENT
    //revision (VIN652, MAY 30, 2017)

    //WEB REFERENCES (reference to VIN65 web service)
    //com.vin65.webservicesContact     
    //com.vin65.webservicesInventory
    //com.vin65.webservicesOrder
    //com.vin65.webservicesProduct

    //PROXY CLASS FILES (generated from WSDL.EXE)
    //  eg. 				wsdl https://webservices.vin65.com/V301/OrderService.cfc?wsdl
    //                      wsdl https://webservices.vin65.com/V300/ProductService.cfc?wsdl
    //          			wsdl https://webservices.vin65.com/V300/InventoryService.cfc?wsdl
    //          			wsdl https://webservices.vin65.com/V300/ContactService.cfc?wsdl
    //ContactServiceService.cs
    //InventoryServiceService.cs
    //OrderServiceService.cs
    //ProductServiceService.cs
    //  Renamed all CLASSES, DELEGATES, EVENTS (added PREFIX)
    //      *** EXCEPT, (Error) could not have a prefix ***
    //  OS_     Order Service
    //  PS_     Product Service
    //  IS_     Inventory Service
    //  CS_     Contact Service 
    //  CMS_    Club Membership Service
    //  CCS_    Credit Card Service
    //  GCS_    Gift Card Service
    //  NS_     Note Service
    //  MCS_    Master Contact Service 
    //  LBS_    List (Builder) Service

    //CONTROLLER
    //MyConnection.cs   (username and password for web service)(should match WEB SERVICE ACCOUNT)
    //ProductController.cs

    //????????????????????????????????????????????????
    //TODO
    //System.Net.WebException: 'The remote name could not be resolved: 'webservices.vin65.com''
    //HOW TO CHECK (WIFI) is up?
    //HOW TO CHECK (VIN65) is up? before running queries?
    //separate code into Product, Inventory, etc (scalability)
    //keep connection code separate?
    //call CONSOLE like VIEW or FORM
    //AMBIGUITY between two WSDL.EXE proxy class files?

    //HOW TO HANDLE (MANY PRODUCTS)(15,000+)(is this accurate?)
    //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
    //recordCountField or response.recordCount = 1176 (on live site)
    //response.productsField (max'd out at 100 in the array)
    //what are the limits? (array, response, etc?)(how to handle?)

    //response must be (TRUE)
    //System.NullReferenceException: 'Object reference not set to an instance of an object.'

    //TEST INCORRECT (username and password)
    //PRINT ERRORS, [0], (ErrorCode, ErrorMessage, errorCodeField, errorMessageField)

    //user interface?
    //log file? (if automated)
    //how are they MANUALLY UPDATING?
    //????????????????????????????????????????????????

    //SET A VIEW (Windows Form) PROJECT, that I can reference...

    //LOG FILE (for success or not)
    //WRITE XML FILE ...

    class Program
    {
        static void Main(string[] args)
        {
            //TESTING...PRODUCTS
            //TestProducts.TestGetProductDetails1();
            //TestProducts.TestGetProductDetails2();
            //TestProducts.TestAddUpdateProduct1();
            TestProducts.TestDumpAllProductDetailsLong();
            TestProducts.TestDumpAllProductDetailsShort();

            //????????????
            //TestProducts.TestProductHierarchy();                //print display (not nested...)
            //TestProducts.TestProductHierarchy2();               //???(broken)??? trying to display (all properties and nested) dynamically
            //????????????

            //TESTING...INVENTORY
            //TestInventory.TestSearchInventory1();
            //TestInventory.TestSearchInventory2();
            //TestInventory.TestAddUpdateInventory1();
            //TestInventory.TestAddUpdateInventory2();
            //TestInventory.TestAddUpdateInventory3();

            //******************************************************************************
            //******************************************************************************


            //USERNAME AND PASSWORD (VIN65 API)
            //string WS_USERNAME = "DeanJonesSANDBOX";
            //string WS_PASSWORD = "willowpark";

            //Program prgm = new Program();
            //prgm.abc();

            //ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);
            //product.PS_SearchProductBySKU("739242");
            //Console.WriteLine("******");
            //Console.WriteLine(product.PS_Response.Products[0].ProductID);


            ////-------------------
            ////SEARCH ALL PRODUCTS
            //List<PS_Product1> products = new List<PS_Product1>();
            ////PS_Product1[] products = new PS_Product1[]();
            //products = pc.PS_SearchAllProducts();
            //Console.WriteLine("******");
            //Console.WriteLine("Count: " + products.Count);
            //Console.WriteLine("id: " + products[0].ProductID);
            //Console.WriteLine("id: " + products[1].ProductID);
            //Console.WriteLine("id: " + products[2].ProductID);
            //Console.WriteLine("id: " + products[3].ProductID);
            //Console.WriteLine("******");

            ////PRINT (all products)
            //Console.WriteLine(prgm.AllProductsToString(products));
            ////-------------------

            ////SEARCH FOR (ONE PRODUCT)
            //Console.WriteLine("--------------");
            //PS_Product1 product = new PS_Product1();
            //product = pc.PS_SearchProductBySKU("739242");
            //Console.WriteLine(prgm.OneProductToString(product));

            ////product to file...
            ////pc.PS_ProductToXmlFile(product);

            ////PRINT XML TO CONSOLE...
            //ProductController pc2 = new ProductController(WS_USERNAME, WS_PASSWORD);
            //Console.WriteLine("--------------");
            //Console.WriteLine("--------------");
            //Console.WriteLine(XmlController.Serialize(pc2.PS_SearchAllProducts2()));

            ////WRITE TO FILE
            //string xmlPath = @"c:\_temp";
            //string xmlString = XmlController.Serialize(pc2.PS_SearchAllProducts2());
            //XmlController.WriteXMLToFile(xmlString, xmlPath);

            Console.Read();     //keep console window open
        }

        //RETURN STRING (for ALL Products)
        public string AllProductsToString(List<PS_Product1> products)
        {
            int num;
            StringBuilder sb = new StringBuilder();

            if (products != null)            
            {
                //get number of Products
                //double? num = response.RecordCount;       //1176 causes error (array and count don't match?)
                num = products.Count;             //100

                for (int i = 0; i < num; i++)
                {
                    sb.Append("\n#: " + (i + 1));
                    sb.Append("\nBrand: " + "\t" + products[i].Brand);
                    sb.Append("\nDateModified: " + "\t" + products[i].DateModified);
                    sb.Append("\nPrice: " + "\t\t" + "$" + products[i].Price);
                    sb.Append("\nProductID: " + "\t" + products[i].ProductID);
                    sb.Append("\nSKU: " + "\t\t" + products[i].SKU);
                    sb.Append("\nSalePrice: " + "\t" + "$" + products[i].SalePrice);
                    sb.Append("\nTitle: " + "\t\t" + products[i].Title);
                    sb.Append("\nType: " + "\t\t" + products[i].Type);
                    sb.Append("\nVintage: " + "\t" + products[i].Vintage);
                    sb.Append("\nWebsiteID: " + "\t" + products[i].WebsiteID);
                    sb.Append("\nisActive: " + "\t" + products[i].isActive);
                    sb.Append("\n---");
                }
            }
            //else
            //{
            //    sb.Append("\nThe RESPONSE was NOT successful: " + response.IsSuccessful);
            //    sb.Append("\nERRORS");
            //    for (int i = 0; i < response.Errors.Length; i++)
            //    {
            //        sb.Append("\n---");
            //        sb.Append("\nErrorCode: " + response.Errors[i].ErrorCode);
            //        sb.Append("\nErrorCode: " + response.Errors[i].ErrorMessage);
            //        sb.Append("\n---");
            //    }
            //}

            return sb.ToString();
        }

        //RETURN STRING (for ALL Products)
        public string OneProductToString(PS_Product1 product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nProduct searched by: " + product.SKU);
            sb.Append("\n---");
            sb.Append("\nBrand: " + "\t" + product.Brand);
            sb.Append("\nDateModified: " + "\t" + product.DateModified);
            sb.Append("\nPrice: " + "\t\t" + "$" + product.Price);
            sb.Append("\nProductID: " + "\t" + product.ProductID);
            sb.Append("\nSKU: " + "\t\t" + product.SKU);
            sb.Append("\nSalePrice: " + "\t" + "$" + product.SalePrice);
            sb.Append("\nTitle: " + "\t\t" + product.Title);
            sb.Append("\nType: " + "\t\t" + product.Type);
            sb.Append("\nVintage: " + "\t" + product.Vintage);
            sb.Append("\nWebsiteID: " + "\t" + product.WebsiteID);
            sb.Append("\nisActive: " + "\t" + product.isActive);
            sb.Append("\n---");
  
            return sb.ToString();
        }

        //https://stackoverflow.com/questions/13266496/easily-write-a-whole-class-instance-to-xml-file-and-read-back-in
        //CREATE XML FILE FROM OBJECT
        public void abc()
        {
            //var garage = new theGarage();
            Sample sample = new Sample();
            sample.FirstName = "Dean";
            sample.LastName = "Jones";


            // TODO init your garage..

            //XmlSerializer xs = new XmlSerializer(typeof(theGarage));
            XmlSerializer xs = new XmlSerializer(typeof(Sample));
            TextWriter tw = new StreamWriter(@"c:\_temp\sample.xml");
            xs.Serialize(tw, sample);
            //TextWriter tw = new StreamWriter(@"c:\temp\garage.xml");
            //xs.Serialize(tw, garage);
        }

    }
}
