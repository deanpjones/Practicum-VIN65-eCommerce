using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpicorEagleMySQLView.Model
{
    public class Validator
    {
        //validate text is an integer
        public static bool IsInteger(string mystring, out int n)
        {           
            return int.TryParse(mystring, out n);
        }

        //test for integer (REGULAR EXPRESSION)
        public static bool IsIntegerRegEx(string mystring)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(mystring);
        }
    }
}
