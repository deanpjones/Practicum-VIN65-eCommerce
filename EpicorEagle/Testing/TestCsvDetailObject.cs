using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Model;

namespace EpicorEagle.Testing
{
    public static class TestCsvDetailObject
    {
        public static void MyTestCsvDetailObject()
        {
            //create detail object
            EpicorCsvDetail detail = new EpicorCsvDetail();

            //add property details...
            //1  2           3       4                                 10          13        14        15        16
            //D  (J140BRNXL) (J140)  (Carhartt Active Jac Quilted)     00000       00001000  00063640  00006364  00000000

            //1-4
            detail.RecordId = "Z";  //see if it changes to default('D')
            detail.Sku = "J140BRNXL";
            detail.ItemTransactionType = " ";
            detail.Description = "J140 Carhartt Active Jac Quilted";

            //10
            detail.SetDiscountPercent(0d);

            //13-16
            detail.SetQuantity(1d);
            detail.SetUnitPrice(63.64d);
            detail.SetExtendedPrice(63.64d);
            detail.SetUnitCost(0d);


            Console.WriteLine("TOSTRING");
            Console.WriteLine(detail.ToString());           //test tostring
            Console.WriteLine("--------------------------");

            //------------------------------------
            //compare strings (should line up)(but I think formatting is different)
            string sample = "DJ140BRNXL      J140 Carhartt Active Jac Quilted     00000       00001000000636400000636400000000";
            Console.WriteLine("--- sample ---");
            Console.WriteLine(sample);
            //---
            //PRINT CSV DETAIL METHOD
            Console.WriteLine("--- from method ---");
            Console.WriteLine(detail.PrintCsvDetail());     //print what output to file will look like?
            //------------------------------------

            //print string length
            string str = detail.PrintCsvDetail();
            Console.WriteLine("CSV String length: {0}", str.Length);    //should end at 481 (like Epicor formatting)


        }


    }
}
