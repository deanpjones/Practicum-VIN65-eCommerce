using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpicorEagle.Model;
using System.ComponentModel;

namespace EpicorEagle.Testing
{
    //DEAN JONES
    //JUL.05, 2017
    //TEST CODE FOR... CSV (FLAT OR FIXED WIDTH FILE) FORMATTING

    static class TestCSV
    {
        public static void Test1()
        {
            //TEST PLAIN TEXT
            string s1 = "SARAHZ";
            s1 = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatTextPadRight(s1, 10, ' ');
            Console.WriteLine(s1 + "...");
            Console.WriteLine("String length: " + s1.Length);

            ////TEST... (new format)
            string test1 = "DEANJ";
            test1 = test1.CsvFormatTextPadRight(10, ' ');
            Console.WriteLine(test1 + "...");

            //TEST PLAIN TEXT ("H")(only has one character, work with formatting?)
            string recordId = "H";
            recordId = recordId.CsvFormatTextPadRight(1, ' ');
            Console.WriteLine("..." + recordId + "...");

            Console.WriteLine();    //line break

            //----------------------------------------------------------------
            //----------------------------------------------------------------
            //TEST CURRENCY 1
            string s2;
            s2 = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatCurrency(57.75d);
            Console.WriteLine(s2);
            Console.WriteLine("String length: " + s2.Length);

            ////TEST... (new format)
            double d1 = 124.25d;
            string str1 = d1.CsvFormatCurrency();
            Console.WriteLine("new format: " + str1);

            //TEST CURRENCY 1b
            string s2b;
            s2b = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatCurrency(-57.75d);       //test negative value
            Console.WriteLine(s2b);
            Console.WriteLine("String length: " + s2b.Length);

            //------------------------------------
            Console.WriteLine();    //line break

            //TEST CURRENCY 2
            string s3;
            s3 = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatCurrency(57.75d, 8, 3);   //test longer format
            Console.WriteLine(s3);
            Console.WriteLine("String length: " + s3.Length);

            ////TEST... (new format)
            double d2 = 224.25d;
            string str2 = d2.CsvFormatCurrency(8, 4);
            Console.WriteLine("new format: " + str2);

            //TEST CURRENCY 3
            string s4;
            s4 = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatCurrency(57.75d, 7, 2);   //test correct format
            Console.WriteLine(s4);
            Console.WriteLine("String length: " + s4.Length);

            //TEST CURRENCY 3b
            string s4b;
            s4b = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatCurrency(-57.75d, 7, 2);   //test negative value
            Console.WriteLine(s4b);
            Console.WriteLine("String length: " + s4b.Length);
            //----------------------------------------------------------------
            //----------------------------------------------------------------

            Console.WriteLine();    //line break

            //TEST PLAIN NUMBER
            string s5;
            s5 = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatNumberPadLeft(200137d, 8);     //test 8 digits
            Console.WriteLine(s5);
            Console.WriteLine("String length: " + s5.Length);

            //TEST PLAIN NUMBER
            string s5b;
            s5b = EpicorEagle.Model.EpicorCsvFormatting.CsvFormatNumberPadLeft(200137d, 6);     //test 6 digits (proper format)
            Console.WriteLine(s5b);
            Console.WriteLine("String length: " + s5b.Length);

            ////TEST... (new format)
            double d3 = 200137d;
            string str3 = d3.CsvFormatNumberPadLeft(10);
            Console.WriteLine("new format: " + str3);
            //----------------------------------------------------------------
            //----------------------------------------------------------------




        }
    }
}
