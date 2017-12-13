using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWS_Middleware.Testing;

namespace WPWS_Middleware
{
    class Program
    {
        static void Main(string[] args)
        {
            //test1
            TestConvert.TestConvertEpicorToVin65();

            Console.Read(); //hold console open
        }
    }
}
