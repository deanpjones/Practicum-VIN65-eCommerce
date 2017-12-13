using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Model
{
    //DEAN JONES
    //JUL.05, 2017
    //CSV (FLAT OR FIXED WIDTH FILE) FORMATTING

    public static class EpicorCsvFormatting
    {

        //"C:\Users\Pythagoras\Desktop\Practicum Docs\705 - Transaction (procedure from Sarah)\EpicorEagleCSVFormat er_d112-021 Integrator format.pdf"
        //formatting methods 

        //METHOD PLAIN TEXT (from string)(to string)(RIGHT PADDING)
        //format x(01)
        //example (CsvFormatText("SARAHZ", 10, ' '));
        //example (mystring.CsvFormatTextPadRight(10, ' '));
        //return ("SARAHZ     ")
        public static string CsvFormatTextPadRight(this string s, int paddingNo, char paddingDelim)
        {
            s = s.PadRight(paddingNo, paddingDelim);
            return s;
        }

        //METHOD CURRENCY (from double)(to string)
        //format 9(7)v9(2)(+/-)
        //example (CsvFormatCurrency(57.75d));
        //example (mydouble.CsvFormatCurrency());
        //return ("000005775+")
        public static string CsvFormatCurrency(this double d)
        {
            string s = d.ToString("0000000.00+;0000000.00-");       //convert to string (add padding)
            s = s.Replace(".", "");                                 //remove decimal 

            return s;
        }

        //METHOD CURRENCY (from double)(to string)
        //format 9(7)v9(2)(+/-) (zero filled)
        //example (CsvFormatCurrency(57.75d, 7, 2);
        //example (mydouble.CsvFormatCurrency(7, 2));
        //return ("000005775+")
        public static string CsvFormatCurrency(this double d, int paddingBeforeDecimal, int paddingAfterDecimal)
        {
            //get format from parameters
            string x = "0";                                             //left zero filled
            string y1 = "";
            for (int i = 0; i < paddingBeforeDecimal; i++) { y1 += x; } //"0000000"
            string y2 = "";
            for (int i = 0; i < paddingAfterDecimal; i++) { y2 += x; }  //"00"

            //build format
            string format = y1 + "." + y2 + "+;" + y1 + "." + y2 + "-"; //"0000000.00+;0000000.00-"
            //string s = d.ToString("0000000.00+;0000000.00-");         //convert to string (add padding)
            string s = d.ToString(format);                              //convert to string (add padding)
            s = s.Replace(".", "");                                     //remove decimal 

            return s;
        }

        //METHOD CURRENCY (from double)(to string)
        //format 9(5)v9(3) (zero filled)(UNSIGNED, no +/-)
        //example (CsvFormatUCurrency(57.75d, 5, 3);
        //example (mydouble.CsvFormatUCurrency(5, 3));
        //return ("00057750")
        public static string CsvFormatUCurrency(this double d, int paddingBeforeDecimal, int paddingAfterDecimal)
        {
            //get format from parameters
            string x = "0";                                             //left zero filled
            string y1 = "";
            for (int i = 0; i < paddingBeforeDecimal; i++) { y1 += x; } //"00000"
            string y2 = "";
            for (int i = 0; i < paddingAfterDecimal; i++) { y2 += x; }  //"000"

            //build format
            string format = y1 + "." + y2;                              //"00000.000"
            //string s = d.ToString("0000000.00+;0000000.00-");         //convert to string (add padding)
            string s = d.ToString(format);                              //convert to string (add padding)
            s = s.Replace(".", "");                                     //remove decimal 

            return s;
        }

        //METHOD PLAIN NUMBER (from double)(to string)
        //format 9(06) (zero filled)
        //example (CsvFormatNumberPadLeft(200137d, 6);
        //example (mydouble.CsvFormatCurrency(6));
        //return ("200137")
        public static string CsvFormatNumberPadLeft(this double d, int padding)
        {
            //get format from parameters
            string x = "0";                                             //left zero filled
            string y1 = "";
            for (int i = 0; i < padding; i++) { y1 += x; }              //"0000000"

            //build format
            string format = y1;                                         //"0000000"
            string s = d.ToString(format);                              //convert to string (add padding)

            return s;
        }


    }
}
