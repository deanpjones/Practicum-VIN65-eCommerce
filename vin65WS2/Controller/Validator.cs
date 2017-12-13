using System;
using System.Windows.Forms;

namespace vin65WS2
{
    //**********************************************************************
    //**********************************************************************

    //VALIDATION
    //Author: Dean Jones
    //Date: Jun.02, 2017 (started Nov.26, 2016)

    //**********************************************************************
    //**********************************************************************

    public static class Validator
    {
        // Validate (empty textbox)
        public static bool IsPresent(TextBox tb)
        {
            if(tb.Text != "")   //Test if EMPTY STRING in TEXTBOX
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " is empty and is required", "Input Error");
                tb.Focus();     //Put FOCUS back to where ERROR happened.
                return false;
            }
        }

        //Validate (is unique value, compare column values in list)

        //Validate (is negative)

        //Validate (is an integer)
        public static bool IsInteger(TextBox tb)
        {
            int num;
            if (int.TryParse(tb.Text, out num))
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " has to be an integer value", "Input Error");
                tb.Focus();     //Put FOCUS back to where ERROR happened.
                return false;
            }
        }

        //Validate (is an integer)
        public static bool IsInteger(string str)
        {
            int num;
            if (int.TryParse(str, out num))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The string is not an integer", "Invalid Input");
                return false;
            }
        }

        //Validate (is positive)(*** TEST FOR INTEGER FIRST ***)
        public static bool IsPositiveInteger(TextBox tb)
        {
            if (Convert.ToInt32(tb.Text) > 0)
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " has to be a positive value", "Input Error");
                tb.Focus();     //Put FOCUS back to where ERROR happened.
                return false;
            }
        }

        // Validate (is a double)
        public static bool IsDouble(TextBox tb)
        {
            double num;    // test for trying parse
            if (Double.TryParse(tb.Text, out num))
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " has to be a double value", "Input Error");
                tb.Focus();     //Put FOCUS back to where ERROR happened.
                return false;
            }
        }

        // Validate (is a decimal)
        public static bool IsDecimal(TextBox tb)
        {
            decimal num;    // test for trying parse
            if(Decimal.TryParse(tb.Text, out num))
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " has to be a decimal value", "Input Error");
                tb.Focus();     //Put FOCUS back to where ERROR happened.
                return false;
            }
        }

        // Validate (is string (# of characters) within range)
        public static bool IsStringWithinRange(TextBox tb, int min, int max)
        {
            int value = tb.Text.Length;
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " must be within range from " + min + ".." + max, "String (# of characters) Input Range Error");
                tb.Focus();
                return false;
            }
        }

        // Validate (is integer within range)
        public static bool IsIntegerWithinRange(TextBox tb, int min, int max)
        {
            int value = Convert.ToInt32(tb.Text);
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " must be within range from " + min + ".." + max, "Integer Input Range Error");
                tb.Focus();
                return false;
            }
        }

        // Validate (is decimal within range)
        public static bool IsDecimalWithinRange(TextBox tb, decimal min, decimal max)
        {
            decimal value = Convert.ToDecimal(tb.Text);
            if(value >= min && value <= max)
            {
                return true;
            }
            else
            {
                //*** must fill in TAG property on TEXTBOX control ***
                MessageBox.Show(tb.Tag + " must be within range from " + (int) min + ".." + (int) max, "Decimal Input Range Error");
                tb.Focus();
                return false;
            }
        }
    }
}
