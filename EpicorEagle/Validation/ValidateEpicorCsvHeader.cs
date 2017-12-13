using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicorEagle.Model;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace EpicorEagle.Validation
{
    //DEAN JONES
    //JUL.06, 2017
    //VALIDATION (for validating format on EpicorCsvHeader object)

    //supporting files
    //IValidator.cs interface
    //Model/EpicorCsvHeader.cs class file (to test)

    class ValidateEpicorCsvHeader : IValidator<EpicorCsvHeader>
    {
        //METHOD (STRING LENGTH TEST)
        private bool IsStringLength(string s, int fixedStringLength)
        {
            string expression = @"^.{" + fixedStringLength + "}$";                          //(.) tests for any character (except newline)
            //string expression = @"^[a-zA-Z0-9\ ]{" + fixedStringLength + "}$";            //this wasn't working for (+) symbols...
            Regex rgx = new Regex(expression);      //@"^[a-zA-Z0-9\ ]{10}$"
            return rgx.IsMatch(s);
        }

        public bool Validate(EpicorCsvHeader ep)
        {
            //LOOP THROUGH ALL PROPERTIES (faster than writing code for EACH element)
            List<string> myPropNameList = new List<string>();
            List<string> myPropValueList = new List<string>();

            //create two lists...
            foreach (PropertyDescriptor myproperty in TypeDescriptor.GetProperties(ep))
            {
                string propName = myproperty.Name;              //get property name
                myPropNameList.Add(propName);                   //add property name to list

                object propValue = myproperty.GetValue(ep);     //get property name
                myPropValueList.Add(propValue.ToString());      //add property name to list
            }

            //list of test... (see formatting key)
            //eg.   x(01), 9(08), 9(06), x(01), 9(06)       = {1, 8, 6, 1, 6}
            int[] stringLengthList = new int[56] {
                    1, 8, 6, 1, 6,
                    3, 3, 5, 1, 4,
                    10, 12, 10, 1, 2,
                    10, 10, 30, 30, 30,
                    30, 30, 30, 30, 10,

                    //*****************

                    19, 10, 5, 10, 8, 
                    8, 3, 8, 1, 10,
                    10, 10, 10, 6, 10,
                    16, 6, 2, 1, 1,
                    1, 3, 1, 2, 1,
                    4, 1, 8, 3, 3, 
                    1

                    //*** NEED TO ADD REMAINING FIELDS, THEN APPROPRIATE INTEGERS here ***
            };
           
            //put two lists together (property name and value)
            var propNameValue = myPropNameList.Zip(myPropValueList, (k, v) => new { Name = k, Value = v });
            //var numbersAndWords = numbers.Zip(words, (n, w) => new { Number = n, Word = w });

            //put two lists together (property and string length)
            var propNameValueAndStringLength = propNameValue.Zip(stringLengthList, (p, n) => new { Property = p, StringLength = n });

            //put (string length value) into loop
            int i = 0;      //track the property number
            foreach (var x in propNameValueAndStringLength)
            {
                i++;
                //------------------------------------
                //test each property (throw exception)
                if (!IsStringLength(x.Property.Value.ToString(), x.StringLength))
                {
                    string message = i + ": The " + x.Property.Name + " string is not the correct length: " + x.StringLength;
                    throw new ArgumentException(message, x.Property.Name);
                }
                //------------------------------------

                //------------------------------------
                //write code to console
                //************ COMMENTED OUT (for generating code) *************
                //StringBuilder sb = new StringBuilder();
                //sb.Append("else if (!IsStringLength(ep." + x.Property.Name + ", " + x.StringLength + "))");
                //sb.Append("\n{");
                //sb.Append("\n\tthrow new ArgumentException(\"The " + x.Property.Name + " string is not the correct length\", \"" + x.Property.Name + "StringLength\");");
                //sb.Append("\n}");
                //sb.Append("\n");

                //Console.WriteLine(sb.ToString());
                //**************************************************************

                //else if (!IsStringLength(ep.TransactionDate, 8))
                //{
                //    throw new ArgumentException("The TransactionDate string is not the correct length", "TransactionDateStringLength");
                //}
                //------------------------------------

                //Console.WriteLine(x.Name + ", " + x.Value);
                //Console.WriteLine(x.Property.Name + ", " + x.Property.Value + ",," + x.StringLength);
            }

            return true;

            //-------------------------------------------------------------
            //*** CREATE CODE (USING CONSOLE WRITELINE...) ***

            //(see loop above, shorter code)
            //test each property (throw exception)
            //if (!IsStringLength(ep.RecordId, 1))
            //{
            //    throw new ArgumentException("The RecordId string is not the correct length", "RecordIdStringLength");
            //    // return false;
            //}
            //else if (!IsStringLength(ep.TransactionDate, 8))
            //{
            //    throw new ArgumentException("The TransactionDate string is not the correct length", "TransactionDateStringLength");
            //}
            //else if (!IsStringLength(ep.TransactionDate, 8))
            //{
            //    throw new ArgumentException("The TransactionDate string is not the correct length", "TransactionDateStringLength");
            //}
            //else
            //{
            //    return true;
            //}
            
            //---------
            //alternative code... (needs up to 56 properties...)
            //if (!IsStringLength(ep.RecordId, 1))
            //{
            //    throw new ArgumentException("The RecordId string is not the correct length", "RecordIdStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionDate, 8))
            //{
            //    throw new ArgumentException("The TransactionDate string is not the correct length", "TransactionDateStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionTime, 6))
            //{
            //    throw new ArgumentException("The TransactionTime string is not the correct length", "TransactionTimeStringLength");
            //}

            //else if (!IsStringLength(ep.StoreNo, 1))
            //{
            //    throw new ArgumentException("The StoreNo string is not the correct length", "StoreNoStringLength");
            //}

            //else if (!IsStringLength(ep.CustomerNo, 6))
            //{
            //    throw new ArgumentException("The CustomerNo string is not the correct length", "CustomerNoStringLength");
            //}

            //else if (!IsStringLength(ep.JobNo, 3))
            //{
            //    throw new ArgumentException("The JobNo string is not the correct length", "JobNoStringLength");
            //}

            //else if (!IsStringLength(ep.TaxCode, 3))
            //{
            //    throw new ArgumentException("The TaxCode string is not the correct length", "TaxCodeStringLength");
            //}

            //else if (!IsStringLength(ep.SalesTaxRate, 5))
            //{
            //    throw new ArgumentException("The SalesTaxRate string is not the correct length", "SalesTaxRateStringLength");
            //}

            //else if (!IsStringLength(ep.PricingIndicator, 1))
            //{
            //    throw new ArgumentException("The PricingIndicator string is not the correct length", "PricingIndicatorStringLength");
            //}

            //else if (!IsStringLength(ep.PricingPercent, 4))
            //{
            //    throw new ArgumentException("The PricingPercent string is not the correct length", "PricingPercentStringLength");
            //}

            //else if (!IsStringLength(ep.Clerk, 10))
            //{
            //    throw new ArgumentException("The Clerk string is not the correct length", "ClerkStringLength");
            //}

            //else if (!IsStringLength(ep.PurchaseOrderNo, 12))
            //{
            //    throw new ArgumentException("The PurchaseOrderNo string is not the correct length", "PurchaseOrderNoStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionTotal, 10))
            //{
            //    throw new ArgumentException("The TransactionTotal string is not the correct length", "TransactionTotalStringLength");
            //}

            //else if (!IsStringLength(ep.SaleTaxable, 1))
            //{
            //    throw new ArgumentException("The SaleTaxable string is not the correct length", "SaleTaxableStringLength");
            //}

            //else if (!IsStringLength(ep.SalesPersonNo, 2))
            //{
            //    throw new ArgumentException("The SalesPersonNo string is not the correct length", "SalesPersonNoStringLength");
            //}

            //else if (!IsStringLength(ep.TotalSalesTax, 10))
            //{
            //    throw new ArgumentException("The TotalSalesTax string is not the correct length", "TotalSalesTaxStringLength");
            //}

            //else if (!IsStringLength(ep.Unused, 10))
            //{
            //    throw new ArgumentException("The Unused string is not the correct length", "UnusedStringLength");
            //}

            //else if (!IsStringLength(ep.Instructions1, 30))
            //{
            //    throw new ArgumentException("The Instructions1 string is not the correct length", "Instructions1StringLength");
            //}

            //else if (!IsStringLength(ep.Instructions2, 30))
            //{
            //    throw new ArgumentException("The Instructions2 string is not the correct length", "Instructions2StringLength");
            //}

            //else if (!IsStringLength(ep.ShipToName, 30))
            //{
            //    throw new ArgumentException("The ShipToName string is not the correct length", "ShipToNameStringLength");
            //}

            //else if (!IsStringLength(ep.ShipToAddress1, 30))
            //{
            //    throw new ArgumentException("The ShipToAddress1 string is not the correct length", "ShipToAddress1StringLength");
            //}

            //else if (!IsStringLength(ep.ShipToAddress2, 30))
            //{
            //    throw new ArgumentException("The ShipToAddress2 string is not the correct length", "ShipToAddress2StringLength");
            //}

            //else if (!IsStringLength(ep.ShipToAddress3, 30))
            //{
            //    throw new ArgumentException("The ShipToAddress3 string is not the correct length", "ShipToAddress3StringLength");
            //}

            //else if (!IsStringLength(ep.ReferenceInfo, 30))
            //{
            //    throw new ArgumentException("The ReferenceInfo string is not the correct length", "ReferenceInfoStringLength");
            //}

            //else if (!IsStringLength(ep.CustomerTelephone, 10))
            //{
            //    throw new ArgumentException("The CustomerTelephone string is not the correct length", "CustomerTelephoneStringLength");
            //}

            //else if (!IsStringLength(ep.CustomerResaleNo, 19))
            //{
            //    throw new ArgumentException("The CustomerResaleNo string is not the correct length", "CustomerResaleNoStringLength");
            //}

            //else if (!IsStringLength(ep.CustomerId, 10))
            //{
            //    throw new ArgumentException("The CustomerId string is not the correct length", "CustomerIdStringLength");
            //}

            //else if (!IsStringLength(ep.SpecialOrderVendor, 5))
            //{
            //    throw new ArgumentException("The SpecialOrderVendor string is not the correct length", "SpecialOrderVendorStringLength");
            //}

            //else if (!IsStringLength(ep.TotalDeposit, 10))
            //{
            //    throw new ArgumentException("The TotalDeposit string is not the correct length", "TotalDepositStringLength");
            //}

            //else if (!IsStringLength(ep.ExpectedDeliveryDate, 8))
            //{
            //    throw new ArgumentException("The ExpectedDeliveryDate string is not the correct length", "ExpectedDeliveryDateStringLength");
            //}

            //else if (!IsStringLength(ep.ExpirationDate, 8))
            //{
            //    throw new ArgumentException("The ExpirationDate string is not the correct length", "ExpirationDateStringLength");
            //}

            //else if (!IsStringLength(ep.TerminalNo, 3))
            //{
            //    throw new ArgumentException("The TerminalNo string is not the correct length", "TerminalNoStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionNo, 8))
            //{
            //    throw new ArgumentException("The TransactionNo string is not the correct length", "TransactionNoStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionType, 1))
            //{
            //    throw new ArgumentException("The TransactionType string is not the correct length", "TransactionTypeStringLength");
            //}

            //else if (!IsStringLength(ep.TotalCashTendered, 10))
            //{
            //    throw new ArgumentException("The TotalCashTendered string is not the correct length", "TotalCashTenderedStringLength");
            //}

            //else if (!IsStringLength(ep.ChargeTendered, 10))
            //{
            //    throw new ArgumentException("The ChargeTendered string is not the correct length", "ChargeTenderedStringLength");
            //}

            //else if (!IsStringLength(ep.ChangeGiven, 10))
            //{
            //    throw new ArgumentException("The ChangeGiven string is not the correct length", "ChangeGivenStringLength");
            //}

            //else if (!IsStringLength(ep.TotalCheckTendered, 10))
            //{
            //    throw new ArgumentException("The TotalCheckTendered string is not the correct length", "TotalCheckTenderedStringLength");
            //}

            //else if (!IsStringLength(ep.CheckNo, 6))
            //{
            //    throw new ArgumentException("The CheckNo string is not the correct length", "CheckNoStringLength");
            //}

            //else if (!IsStringLength(ep.BankCardTendered, 10))
            //{
            //    throw new ArgumentException("The BankCardTendered string is not the correct length", "BankCardTenderedStringLength");
            //}

            //else if (!IsStringLength(ep.BankCardNo, 16))
            //{
            //    throw new ArgumentException("The BankCardNo string is not the correct length", "BankCardNoStringLength");
            //}

            //else if (!IsStringLength(ep.ApplyToNo, 6))
            //{
            //    throw new ArgumentException("The ApplyToNo string is not the correct length", "ApplyToNoStringLength");
            //}

            //else if (!IsStringLength(ep.ThirdPartyVendor, 2))
            //{
            //    throw new ArgumentException("The ThirdPartyVendor string is not the correct length", "ThirdPartyVendorStringLength");
            //}

            //else if (!IsStringLength(ep.UseESTUcost, 1))
            //{
            //    throw new ArgumentException("The UseESTUcost string is not the correct length", "UseESTUcostStringLength");
            //}

            //else if (!IsStringLength(ep.PrivateLabelCardType, 1))
            //{
            //    throw new ArgumentException("The PrivateLabelCardType string is not the correct length", "PrivateLabelCardTypeStringLength");
            //}

            //else if (!IsStringLength(ep.SpecialTransactionProcessingFlag, 1))
            //{
            //    throw new ArgumentException("The SpecialTransactionProcessingFlag string is not the correct length", "SpecialTransactionProcessingFlagStringLength");
            //}

            //else if (!IsStringLength(ep.PrivateLabelCardPromoType, 3))
            //{
            //    throw new ArgumentException("The PrivateLabelCardPromoType string is not the correct length", "PrivateLabelCardPromoTypeStringLength");
            //}

            //else if (!IsStringLength(ep.TdxTransaction, 1))
            //{
            //    throw new ArgumentException("The TdxTransaction string is not the correct length", "TdxTransactionStringLength");
            //}

            //else if (!IsStringLength(ep.Unused2, 2))
            //{
            //    throw new ArgumentException("The Unused2 string is not the correct length", "Unused2StringLength");
            //}

            //else if (!IsStringLength(ep.DirectShip, 1))
            //{
            //    throw new ArgumentException("The DirectShip string is not the correct length", "DirectShipStringLength");
            //}

            //else if (!IsStringLength(ep.TransactionCodes, 4))
            //{
            //    throw new ArgumentException("The TransactionCodes string is not the correct length", "TransactionCodesStringLength");
            //}

            //else if (!IsStringLength(ep.ShipViaCode, 1))
            //{
            //    throw new ArgumentException("The ShipViaCode string is not the correct length", "ShipViaCodeStringLength");
            //}

            //else if (!IsStringLength(ep.RouteNumber, 8))
            //{
            //    throw new ArgumentException("The RouteNumber string is not the correct length", "RouteNumberStringLength");
            //}

            //else if (!IsStringLength(ep.RouteDay, 3))
            //{
            //    throw new ArgumentException("The RouteDay string is not the correct length", "RouteDayStringLength");
            //}

            //else if (!IsStringLength(ep.RouteStop, 3))
            //{
            //    throw new ArgumentException("The RouteStop string is not the correct length", "RouteStopStringLength");
            //}

            //else if (!IsStringLength(ep.DeliveryTimeCode, 1))
            //{
            //    throw new ArgumentException("The DeliveryTimeCode string is not the correct length", "DeliveryTimeCodeStringLength");
            //}

            //else
            //{
            //    return true;
            //}
            //-------------------------------------------------------------

        }


    }
}
