using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Model;
using System.ComponentModel;

namespace EpicorEagle.Testing
{
    public static class TestCsvHeaderObject
    {
        public static void MyTestCsvHeaderObject()
        {
            //SET VALUES
            //create (csv header) object
            EpicorCsvHeader csvHeader = new EpicorCsvHeader();
            //add properties
            csvHeader.RecordId = "H";
            csvHeader.SetTransactionDate(20170630d);
            csvHeader.SetTransactionTime(022300d);
            csvHeader.StoreNo = "1";
            csvHeader.SetCustomerNo(200137d);
            csvHeader.SetJobNo(0d);

            //1   DONE No.				H
            //2   DONE Date             06 / 30 / 17
            //3   DONE Time             02:23 PM
            //4   DONE St               1
            //5   DONE Cust #	        200137	
            //6   DONE Job              0

            csvHeader.SetTransactionTotal(57.75d);
            csvHeader.Clerk = "SARAHZ";                             //"SARAHZxxxxxxxxxxxxxxxx"; (how to validate doesn't exceed limit?)
            csvHeader.PurchaseOrderNo = "13590";

            //11  DONE Total            57.75
            //12  DONE Clerk            SARAHZ
            //13  DONE P.O. #			13590

            //NEW STRING
            //Test print (CSV file format)
            Console.WriteLine("New string");
            Console.WriteLine("***********************************************");
            Console.WriteLine(csvHeader.PrintCsvHeader() + "...end");          
            Console.WriteLine("String Length: {0}", csvHeader.PrintCsvHeader().Length);
            Console.WriteLine("***********************************************");

            Console.WriteLine();    //blank line

            //ORIGINAL STRING
            Console.WriteLine("Original string");
            Console.WriteLine("***********************************************");
            //original header (manually built)
            string builtString = "H063020170223001200137000aaa#####a####SARAHZ    13590       " +
                "000005775+Yaa#########+          aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "Christine Huppe               " +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa??????????";           
            Console.WriteLine(builtString);
            Console.WriteLine("***********************************************");

            //PRINT DETAILS
            Console.WriteLine(csvHeader.ToString());

            //PRINT DETAILS(another way)
            int i = 1;
            Console.WriteLine("-----------------");
            foreach (PropertyDescriptor myproperty in TypeDescriptor.GetProperties(csvHeader))
            {               
                string propName = myproperty.Name;
                object propValue = myproperty.GetValue(csvHeader);
                Console.WriteLine("{2}...{0} = {1}", propName, propValue, i);
                i++;
            }
        }
        
        

    }
}
