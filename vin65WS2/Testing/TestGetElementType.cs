using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vin65WS2.Testing
{
    class TestGetElementType
    {
        public static void immedTest()
        {
            //int[] array = { 1, 2, 3 };
            //Type t = array.GetType();
            //Type t2 = t.GetElementType();
            //Console.WriteLine("The element type of {0} is {1}.", array, t2.ToString());
            //TestGetElementType newMe = new TestGetElementType();
            //t = newMe.GetType();
            //t2 = t.GetElementType();
            //Console.WriteLine("The element type of {0} is {1}.", newMe, t2 == null ? "null" : t2.ToString());

            int[] x = { 1, 2, 3 };
            bool yes;

            Type valueType = x.GetType();
            if (valueType.IsArray)
            {
                yes = true;
            }
            else
            {
                yes = false;
            }

            bool test = x.GetType().IsArray;
        }
    }
}
