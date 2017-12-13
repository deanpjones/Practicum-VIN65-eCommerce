using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VinProduct = vin65WS2.com.vin65.webservicesProduct;       //access the methods directly (instead of using proxy files)
using System.ComponentModel;
using System.Reflection;

namespace vin65WS2.Testing
{
    public static class TestProducts
    {
        //USERNAME AND PASSWORD (VIN65 API)
        static string WS_USERNAME = "DeanJonesSANDBOX";
        static string WS_PASSWORD = "willowpark";

        public static void TestGetProductDetails1()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            //----
            //ERROR 
            //"There is an error in XML document (99, 15)." (THIS FIXED BY PATHING TO 
            VinProduct.Product product = new VinProduct.Product();
            product = pc.PS_GetProductDetailsBySKU("746969c");
            //Console.WriteLine(product.Title);
            //----

            //OBJECT PROPERTY DUMP
            Console.WriteLine("------");
            Console.WriteLine("PRODUCT");
            Utility.Utility.DumpProperties(product);
            Console.WriteLine("------");
            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(product))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(product);
            //    Console.WriteLine("{0}={1}", name, value);
            //}

        }

        public static void TestGetProductDetails2()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);
            VinProduct.Response3 ps_response3 = new VinProduct.Response3();
            ps_response3 = pc.PS_GetProductDetailsBySKU2("746969c");

            Console.WriteLine("------");
            Console.WriteLine("PRODUCT");
            //dump (is success, errors, record count)
            Utility.Utility.DumpProperties(ps_response3);
            //Utility.Utility.DumpProperties2(ps_response3);
            Console.WriteLine("   ---");
            //dump product properties
            Utility.Utility.DumpProperties(ps_response3.Product);
            Console.WriteLine("------");
            
        }

        public static void TestAddUpdateProduct1()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            //get a product (before modifying...)
            VinProduct.Response3 ps_response3 = new VinProduct.Response3();
            ps_response3 = pc.PS_GetProductDetailsBySKU2("746969c");

            //make a change
            if ((bool)ps_response3.IsSuccessful)
            {
                ps_response3.Product.Title = "666 Crimes Shiraz Durif Red Blend";       //reset
                //ps_response3.Product.Title += "testtesttest";
            }

            //update the product
            pc.PS_AddUpdateProduct(ps_response3.Product);
            //Console.WriteLine("Product {0} updated...", ps_response3.Product.SKUs.)

        }

        public static void TestDumpAllProductDetailsShort()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            VinProduct.Product product = new VinProduct.Product();
            product = pc.PS_GetProductDetailsBySKU("746969b");  //"746969c"

            //print short description
            Console.WriteLine(pc.PS_DisplayProductDetailsShort(product));

        }

        public static void TestDumpAllProductDetailsLong()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            VinProduct.Product product = new VinProduct.Product();
            product = pc.PS_GetProductDetailsBySKU("746969b");  //"746969c"

            //print long description
            Console.WriteLine(pc.PS_DisplayProductDetailsLong(product));

        }

        //???????????????
        private static List<bool> loop(Object obj)
        {
            List<bool> myIsArray = new List<bool>();

            Type productType = obj.GetType();
            IList<PropertyInfo> productProperties = new List<PropertyInfo>(productType.GetProperties());
            foreach (PropertyInfo prop in productProperties)
            {
                //get property name 
                object propName = prop.Name;
                //get property value
                object propValue = prop.GetValue(obj, null);
                //get type of object (so I know if it is an array, or other)
                bool IsPropertyAnArray = prop.PropertyType.IsArray;

                Console.WriteLine("{0}: {1}, IsArray: {2}", propName, propValue, IsPropertyAnArray);

                myIsArray.Add(IsPropertyAnArray);
            }

            return myIsArray;
        }

        //???????????????
        public static void TestProductHierarchy2()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            VinProduct.Product product = new VinProduct.Product();
            product = pc.PS_GetProductDetailsBySKU("746969b");  //"746969c"

            List<bool> myIsArray = new List<bool>();
            myIsArray = loop(product);
            foreach(bool propIsArray in myIsArray)
            {
                if (!propIsArray)
                {
                    loop(product);
                }
                else if (propIsArray)
                {
                    loop(propIsArray);      //recursive
                }
                else
                {
                    Console.WriteLine("...something went wrong...");
                }
            }
            

        }

        public static void TestProductHierarchy()
        {
            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);

            VinProduct.Product product = new VinProduct.Product();
            product = pc.PS_GetProductDetailsBySKU("746969b");  //"746969c"

            //get all elements 
            Type productType = product.GetType();
            IList<PropertyInfo> productProperties = new List<PropertyInfo>(productType.GetProperties());
            foreach (PropertyInfo prop in productProperties)
            {
                //get property name 
                object propName = prop.Name;
                //get property value
                object propValue = prop.GetValue(product, null);
                //get type of object (so I know if it is an array, or other)
                bool IsPropertyAnArray = prop.PropertyType.IsArray;

                if (!IsPropertyAnArray)
                {
                    Console.WriteLine("{0}: {1}", propName, propValue);
                }
                else if (IsPropertyAnArray)
                {
                    //go into array and print same...
                    Console.WriteLine("{0}: {1}", propName, propValue);
                }
                else
                {
                    Console.WriteLine("...there is a problem here...");
                }

            }

            //System.Reflection.PropertyInfo[] myarray = productType.GetProperties();
            //var x = myarray.GetValue(0);

            //foreach(PropertyInfo elem in myarray)
            //{
            //    //find key and value 

            //    elem.GetValue(myarray);
            //    //elem.CanRead
            //    //elem.GetValue
            //}

            //Type myType = myObject.GetType();
            //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            //foreach (PropertyInfo prop in props)
            //{
            //    object propValue = prop.GetValue(myObject, null);

            //    // Do something with propValue
            //}

            //for each element in PRODUCT get type 
            // if an array 
            //how long is array 
            //show all elements 
            // if not array (what is it?) single element
            //show one element (key and value)
            // if it's something else how to handle this...
        }


    }
}
