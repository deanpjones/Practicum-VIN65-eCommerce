using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Model;
using EpicorEagle.Validation;

namespace EpicorEagle.Testing
{
    public static class TestCsvHeaderValidation
    {
        public static void MyTestCsvHeaderValidation()
        {
            EpicorCsvHeader csvHeader = new EpicorCsvHeader();
            csvHeader.RecordId = "H";
            csvHeader.SetTransactionDate(20170630d);
            csvHeader.SetTransactionTime(022300d);
            csvHeader.StoreNo = "1";
            csvHeader.SetCustomerNo(200137d);
            csvHeader.SetJobNo(0d);

            try
            {
                //test validate (csv header)
                var validator = new ValidateEpicorCsvHeader();
                if (validator.Validate(csvHeader))                  //*** VALIDATES (entire header) ***
                {
                    //print (csv header) for file
                    Console.WriteLine(csvHeader.PrintCsvHeader());
                    Console.WriteLine("---------------");

                    //print (csv header) details
                    Console.WriteLine(csvHeader.ToString());
                    Console.WriteLine("---------------");

                    Console.WriteLine("\nThe validation was successful");

                    //Console.WriteLine("{0} {1}, the validation worked", csvHeader.RecordId, csvHeader.CustomerNo);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);      //print custom error
            }

        }
//        Customer customer = new Customer();
//        customer.FirstName = "Deanxxxxxx";
//            customer.LastName = "JonesXXXXXT";

//            try
//            {
//                var validator = new CustomerValidator();
//                //if (!validator.Validate(customer))
//                //{
//                //    Console.WriteLine("customer isn't valid");
//                //}
//                //else
//                //{
//                //    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
//                //}
//                if (validator.Validate(customer))
//                {
//                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
//                }

//}
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine(ex.Message);    //ex.ParamName + ", " + ex.Message
//            }
    }
}
