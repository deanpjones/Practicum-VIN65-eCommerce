using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Model
{
    //DEAN JONES
    //JUL.05, 2017
    //CLASS TO BUILD CSV (FLAT OR FIXED WIDTH FILE)
    //create a flat file (in Epicor's format)
    //FLAT FILE (HEADER ONLY)

    //SUPPORTING FILES 
    //Model/EpicorCsvFormatting.cs (CSV formatting methods)
    //Model/EpicorCsvDetail.cs (detail format)
    //Model/EpicorCsv.cs (combine header and list of details)

    //HEADER...(RecordId, TransactionDate, TransactionTime, Store#, Customer#, ...)
    //1  2         3       4  5       6    7    8      9  10    11            12		      13			14  15  16          17
    //H  06302017  022300  1  200137  000  aaa  #####  a  ####  (SARAHZ    )  (13590       )  (000005775+)  Y   aa  #########+  (          )
    //18							 19								 20				                   21						       22                              23
    //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  (Christine Huppe               )  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

    //TODO
    //*** NEED TO ADD REMAINING ((up to 56), GET/SETTERS, DefaultProperties) ***

    class EpicorCsvHeader
    {
        //PROPERTIES
        //1-5
        private string recordId;
        private string transactionDate;
        private string transactionTime;
        private string storeNo;
        private string customerNo;

        //6-10
        private string jobNo;
        private string taxCode;
        private string salesTaxRate;
        private string pricingIndicator;
        private string pricingPercent;

        //11-15
        private string clerk;
        private string purchaseOrderNo;
        private string transactionTotal;
        private string saleTaxable;
        private string salesPersonNo;

        //16-20
        private string totalSalesTax;
        private string unused;
        private string instructions1;
        private string instructions2;
        private string shipToName;

        //21-25
        private string shipToAddress1;
        private string shipToAddress2;
        private string shipToAddress3;
        private string referenceInfo;
        private string customerTelephone;

        //*************
        //PROPERTIES (CONT'D)
        //26-30
        private string customerResaleNo;
        private string customerId;
        private string specialOrderVendor;
        private string totalDeposit;
        private string expectedDeliveryDate;

        //31-35
        private string expirationDate;
        private string terminalNo;
        private string transactionNo;
        private string transactionType;
        private string totalCashTendered;

        //36-40
        private string chargeTendered;
        private string changeGiven;
        private string totalCheckTendered;
        private string checkNo;
        private string bankCardTendered;

        //41-45
        private string bankCardNo;
        private string applyToNo;
        private string thirdPartyVendor;
        private string useESTUcost;
        private string privateLabelCardType;

        //46-50
        private string specialTransactionProcessingFlag;
        private string privateLabelCardPromoType;
        private string tdxTransaction;
        private string unused2;
        private string directShip;

        //51-56
        private string transactionCodes;
        private string shipViaCode;
        private string routeNumber;
        private string routeDay;
        private string routeStop;

        private string deliveryTimeCode;


        //GETTERS AND SETTERS (set formatting here...)
        //1-5
        //------------
        public string RecordId { get => recordId; set => recordId = "H".CsvFormatTextPadRight(1,' '); }     //x(01) (always 'H')
        //---
        public string TransactionDate { get => transactionDate; }      
        public void SetTransactionDate(double d) { transactionDate = d.CsvFormatNumberPadLeft(8); }         //9(08) (explicit setter)(to accept double)
        //---
        public string TransactionTime { get => transactionTime; set => transactionTime = value; }           
        public void SetTransactionTime(double d) { transactionTime = d.CsvFormatNumberPadLeft(6); }         //9(06) (explicit setter)
        //---
        public string StoreNo { get => storeNo; set => storeNo = value.CsvFormatTextPadRight(1, ' '); }     //x(01) 
        //---
        public string CustomerNo { get => customerNo; }
        public void SetCustomerNo(double d) { customerNo = d.CsvFormatNumberPadLeft(6); }                   //9(06) (explicit setter)
        //------------

        //6-10
        //------------
        public string JobNo { get => jobNo; }                                     
        public void SetJobNo(double d) { jobNo = d.CsvFormatNumberPadLeft(3); }                             //9(03) (explicit setter)
        //---
        public string TaxCode { get => taxCode; set => taxCode = value.CsvFormatTextPadRight(3, ' '); }     //x(03) 
        //---
        public string SalesTaxRate { get => salesTaxRate; }                
        public void SetSalesTaxRate(double d) { salesTaxRate = d.CsvFormatNumberPadLeft(5); }               //v9(5) (explicit setter)
        //---
        public string PricingIndicator { get => pricingIndicator; set => pricingIndicator = value.CsvFormatTextPadRight(1, ' '); }      //x(01) 
        //---
        public string PricingPercent { get => pricingPercent; }          
        public void SetPricingPercent(double d) { pricingPercent = d.CsvFormatNumberPadLeft(4); }           //v9(4) (explicit setter)
        //------------

        //11-15
        //------------
        public string Clerk { get => clerk; set => clerk = value.CsvFormatTextPadRight(10, ' '); }                                  //x(10)
        public string PurchaseOrderNo { get => purchaseOrderNo; set => purchaseOrderNo = value.CsvFormatTextPadRight(12, ' '); }    //x(12)
        //---
        public string TransactionTotal { get => transactionTotal; }                                
        public void SetTransactionTotal(double d) { transactionTotal = d.CsvFormatCurrency(7, 2); }         //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string SaleTaxable { get => saleTaxable; set => saleTaxable = value.CsvFormatTextPadRight(1, ' '); }                 //x(01) (default to 'Y')?
        public string SalesPersonNo { get => salesPersonNo; set => salesPersonNo = value.CsvFormatTextPadRight(2, ' '); }           //x(02) 
        //------------

        //16-20
        //------------
        public string TotalSalesTax { get => totalSalesTax; }             
        public void SetTotalSalesTax(double d) { totalSalesTax = d.CsvFormatCurrency(7, 2); }               //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string Unused { get => unused; set => unused = value.CsvFormatTextPadRight(10, ' '); }                                   //x(10) 
        public string Instructions1 { get => instructions1; set => instructions1 = value.CsvFormatTextPadRight(30, ' '); }              //x(30)
        public string Instructions2 { get => instructions2; set => instructions2 = value.CsvFormatTextPadRight(30, ' '); }              //x(30)
        public string ShipToName { get => shipToName; set => shipToName = value.CsvFormatTextPadRight(30, ' '); }                       //x(30)
        //------------

        //21-25
        //------------
        public string ShipToAddress1 { get => shipToAddress1; set => shipToAddress1 = value.CsvFormatTextPadRight(30, ' '); }           //x(30)
        public string ShipToAddress2 { get => shipToAddress2; set => shipToAddress2 = value.CsvFormatTextPadRight(30, ' '); }           //x(30)
        public string ShipToAddress3 { get => shipToAddress3; set => shipToAddress3 = value.CsvFormatTextPadRight(30, ' '); }           //x(30)
        public string ReferenceInfo { get => referenceInfo; set => referenceInfo = value.CsvFormatTextPadRight(30, ' '); }              //x(30)
        public string CustomerTelephone { get => customerTelephone; set => customerTelephone = value.CsvFormatTextPadRight(10, ' '); }  //x(10)        
        //------------

        //******************
        //GETTERS AND SETTERS (CONT'D)
        //26-30
        //------------
        public string CustomerResaleNo { get => customerResaleNo; set => customerResaleNo = value.CsvFormatTextPadRight(19, ' '); }     //x(19)
        public string CustomerId { get => customerId; set => customerId = value.CsvFormatTextPadRight(10, ' '); }                       //x(10)
        public string SpecialOrderVendor { get => specialOrderVendor; set => specialOrderVendor = value.CsvFormatTextPadRight(5, ' '); }//x(05)
        //---
        public string TotalDeposit { get => totalDeposit; }                            
        public void SetTotalDeposit(double d) { totalDeposit = d.CsvFormatCurrency(7, 2); }                                             //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string ExpectedDeliveryDate { get => expectedDeliveryDate; }    
        public void SetExpectedDeliveryDate(double d) { expectedDeliveryDate = d.CsvFormatNumberPadLeft(8); }                           //9(08) (explicit setter)
        //------------

        //31-35
        //------------
        public string ExpirationDate { get => expirationDate; }                      
        public void SetExpirationDate(double d) { expirationDate = d.CsvFormatNumberPadLeft(8); }                                       //9(08) (explicit setter)
        //---
        public string TerminalNo { get => terminalNo; }                                  
        public void SetTerminalNo(double d) { terminalNo = d.CsvFormatNumberPadLeft(3); }                                               //9(03) (explicit setter)
        //---
        public string TransactionNo { get => transactionNo; set => transactionNo = value.CsvFormatTextPadRight(8, ' '); }               //x(08)
        public string TransactionType { get => transactionType; set => transactionType = value.CsvFormatTextPadRight(1, ' '); }         //x(01)
        //---
        public string TotalCashTendered { get => totalCashTendered; }             
        public void SetTotalCashTendered(double d) { totalCashTendered = d.CsvFormatCurrency(7, 2); }                                   //9(7)v9(2)(+/-) (explicit setter)
        //------------

        //36-40
        //------------
        public string ChargeTendered { get => chargeTendered; }                      
        public void SetChargeTendered(double d) { chargeTendered = d.CsvFormatCurrency(7, 2); }                                         //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string ChangeGiven { get => changeGiven; }                               
        public void SetChangeGiven(double d) { changeGiven = d.CsvFormatCurrency(7, 2); }                                               //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string TotalCheckTendered { get => totalCheckTendered; }          
        public void SetTotalCheckTendered(double d) { totalCheckTendered = d.CsvFormatCurrency(7, 2); }                                 //9(7)v9(2)(+/-) (explicit setter)
        //---
        public string CheckNo { get => checkNo; }                                           
        public void SetCheckNo(double d) { checkNo = d.CsvFormatNumberPadLeft(6); }                                                     //9(06) (explicit setter)
        //---
        public string BankCardTendered { get => bankCardTendered; }                
        public void SetBankCardTendered(double d) { bankCardTendered = d.CsvFormatCurrency(7, 2); }                                     //9(7)v9(2)(+/-) (explicit setter)
        //------------

        //41-45
        //------------
        public string BankCardNo { get => bankCardNo; set => bankCardNo = value.CsvFormatTextPadRight(16, ' '); }                               //x(16)
        public string ApplyToNo { get => applyToNo; set => applyToNo = value.CsvFormatTextPadRight(6, ' '); }                                   //x(06)
        public string ThirdPartyVendor { get => thirdPartyVendor; set => thirdPartyVendor = value.CsvFormatTextPadRight(2, ' '); }              //x(02)
        public string UseESTUcost { get => useESTUcost; set => useESTUcost = value.CsvFormatTextPadRight(1, ' '); }                             //x(01)
        public string PrivateLabelCardType { get => privateLabelCardType; set => privateLabelCardType = value.CsvFormatTextPadRight(1, ' '); }  //x(01)
        //------------

        //46-50
        //------------
        public string SpecialTransactionProcessingFlag { get => specialTransactionProcessingFlag; set => specialTransactionProcessingFlag = value.CsvFormatTextPadRight(1, ' '); }  //x(01)
        public string PrivateLabelCardPromoType { get => privateLabelCardPromoType; set => privateLabelCardPromoType = value.CsvFormatTextPadRight(3, ' '); }   //x(03)
        public string TdxTransaction { get => tdxTransaction; set => tdxTransaction = value.CsvFormatTextPadRight(1, ' '); }                    //x(01)
        public string Unused2 { get => unused2; set => unused2 = value.CsvFormatTextPadRight(2, ' '); }                                         //x(02)
        public string DirectShip { get => directShip; set => directShip = value.CsvFormatTextPadRight(1, ' '); }                                //x(01)
        //------------

        //51-56
        //------------
        public string TransactionCodes { get => transactionCodes; set => transactionCodes = value.CsvFormatTextPadRight(4, ' '); }              //x(04)
        public string ShipViaCode { get => shipViaCode; set => shipViaCode = value.CsvFormatTextPadRight(1, ' '); }                             //x(01)
        public string RouteNumber { get => routeNumber; set => routeNumber = value.CsvFormatTextPadRight(8, ' '); }                             //x(08)
        public string RouteDay { get => routeDay; set => routeDay = value.CsvFormatTextPadRight(3, ' '); }                                      //x(03)
        public string RouteStop { get => routeStop; set => routeStop = value.CsvFormatTextPadRight(3, ' '); }                                   //x(03)

        public string DeliveryTimeCode { get => deliveryTimeCode; set => deliveryTimeCode = value.CsvFormatTextPadRight(1, ' '); }              //x(01)
        //------------

        //METHOD DEFAULT PROPERTIES
        private void SetDefaultProperties()
        {
            //1  2         3       4  5       
            //H  06302017  022300  1  200137
            this.recordId = "H".CsvFormatTextPadRight(1, ' ');          //x(01) (always "H")
            this.transactionDate = 0d.CsvFormatNumberPadLeft(8);        //9(08) 
            this.transactionTime = 0d.CsvFormatNumberPadLeft(6);        //9(06) 
            this.storeNo = " ".CsvFormatTextPadRight(1, ' ');           //x(01) 
            this.customerNo = 0d.CsvFormatNumberPadLeft(6);             //9(06)

            //6    7    8      9  10    
            //000  aaa  #####  a  ####  
            this.jobNo = 0d.CsvFormatNumberPadLeft(3);                  //9(03) 
            this.taxCode = " ".CsvFormatTextPadRight(3, ' ');           //x(03) 
            this.salesTaxRate = 0d.CsvFormatNumberPadLeft(5);           //v9(5)
            this.pricingIndicator = " ".CsvFormatTextPadRight(1, ' ');  //x(01) 
            this.pricingPercent = 0d.CsvFormatNumberPadLeft(4);         //v9(4) 

            //11            12		        13			  14  15  
            //(SARAHZ    )  (13590       )  (000005775+)  Y   aa  
            this.clerk = " ".CsvFormatTextPadRight(10, ' ');            //x(10)
            this.purchaseOrderNo = " ".CsvFormatTextPadRight(12, ' ');  //x(12)
            this.transactionTotal = 0d.CsvFormatCurrency(7, 2);         //9(7)v9(2)(+/-)
            this.saleTaxable = " ".CsvFormatTextPadRight(1, ' ');       //x(01) (default to 'Y')?
            this.salesPersonNo = " ".CsvFormatTextPadRight(2, ' ');     //x(02) 

            //16          17            18                              19                              20
            //#########+  (          )  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  (Christine Huppe)
            this.totalSalesTax = 0d.CsvFormatCurrency(7, 2);            //9(7)v9(2)(+/-)
            this.unused = " ".CsvFormatTextPadRight(10, ' ');           //x(10) 
            this.instructions1 = " ".CsvFormatTextPadRight(30, ' ');    //x(30) 
            this.instructions2 = " ".CsvFormatTextPadRight(30, ' ');    //x(30) 
            this.shipToName = " ".CsvFormatTextPadRight(30, ' ');       //x(30) 

            //21                             22                              23                              24                              25
            //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa  aaaaaaaaaa
            this.shipToAddress1 = " ".CsvFormatTextPadRight(30, ' ');   //x(30) 
            this.shipToAddress2 = " ".CsvFormatTextPadRight(30, ' ');   //x(30) 
            this.shipToAddress3 = " ".CsvFormatTextPadRight(30, ' ');   //x(30) 
            this.referenceInfo = " ".CsvFormatTextPadRight(30, ' ');    //x(30) 
            this.customerTelephone = " ".CsvFormatTextPadRight(10, ' ');//x(10) 

            //****************

            //26-30
            this.customerResaleNo = " ".CsvFormatTextPadRight(19, ' ');                 //x(19)
            this.customerId = " ".CsvFormatTextPadRight(10, ' ');                       //x(10)
            this.specialOrderVendor = " ".CsvFormatTextPadRight(5, ' ');                //x(05)
            this.totalDeposit = 0d.CsvFormatCurrency(7, 2);                             //9(7)v9(2)(+/-) 
            this.expectedDeliveryDate = 0d.CsvFormatNumberPadLeft(8);                   //9(08)

            //31-35
            this.expirationDate = 0d.CsvFormatNumberPadLeft(8);                         //9(08)
            this.terminalNo = 0d.CsvFormatNumberPadLeft(3);                             //9(03)
            this.transactionNo = " ".CsvFormatTextPadRight(8, ' ');                     //x(08)
            this.transactionType = " ".CsvFormatTextPadRight(1, ' ');                   //x(01)
            this.totalCashTendered = 0d.CsvFormatCurrency(7, 2);                        //9(7)v9(2)(+/-)

            //36-40
            this.chargeTendered = 0d.CsvFormatCurrency(7, 2);                           //9(7)v9(2)(+/-)
            this.changeGiven = 0d.CsvFormatCurrency(7, 2);                              //9(7)v9(2)(+/-)
            this.totalCheckTendered = 0d.CsvFormatCurrency(7, 2);                       //9(7)v9(2)(+/-)
            this.checkNo = 0d.CsvFormatNumberPadLeft(6);                                //9(06) 
            this.bankCardTendered = 0d.CsvFormatCurrency(7, 2);                         //9(7)v9(2)(+/-)

            //41-45
            this.bankCardNo = " ".CsvFormatTextPadRight(16, ' ');                       //x(16)
            this.applyToNo = " ".CsvFormatTextPadRight(6, ' ');                         //x(06)
            this.thirdPartyVendor = " ".CsvFormatTextPadRight(2, ' ');                  //x(02)
            this.useESTUcost = " ".CsvFormatTextPadRight(1, ' ');                       //x(01)
            this.privateLabelCardType = " ".CsvFormatTextPadRight(1, ' ');              //x(01)

            //46-50
            this.specialTransactionProcessingFlag = " ".CsvFormatTextPadRight(1, ' ');  //x(01)
            this.privateLabelCardPromoType = " ".CsvFormatTextPadRight(3, ' ');         //x(03)
            this.tdxTransaction = " ".CsvFormatTextPadRight(1, ' ');                    //x(01)
            this.unused2 = " ".CsvFormatTextPadRight(2, ' ');                           //x(02)
            this.directShip = " ".CsvFormatTextPadRight(1, ' ');                        //x(01)

            //51-56
            this.transactionCodes = " ".CsvFormatTextPadRight(4, ' ');                  //x(04)
            this.shipViaCode = " ".CsvFormatTextPadRight(1, ' ');                       //x(01)
            this.routeNumber = " ".CsvFormatTextPadRight(8, ' ');                       //x(08)
            this.routeDay = " ".CsvFormatTextPadRight(3, ' ');                          //x(03)
            this.routeStop = " ".CsvFormatTextPadRight(3, ' ');                         //x(03)

            this.deliveryTimeCode = " ".CsvFormatTextPadRight(1, ' ');                  //x(01)

        }


        //CONSTRUCTOR
        public EpicorCsvHeader()    //basic constructor
        {
            //this.recordId = "H".CsvFormatTextPadRight(1, ' ');        //always "H"   
            SetDefaultProperties();
        }


        //TOSTRING OVERRIDE
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nRecordId: " + recordId);
            sb.Append("\nTransactionDate: " + transactionDate);
            sb.Append("\nTransactionTime: " + transactionTime);
            sb.Append("\nStoreNo: " + storeNo);
            sb.Append("\nCustomerNo: " + customerNo);         

            sb.Append("\nJobNo: " + jobNo);
            sb.Append("\nTaxCode: " + taxCode);
            sb.Append("\nSalesTaxRate: " + salesTaxRate);
            sb.Append("\nPricingIndicator: " + pricingIndicator);
            sb.Append("\nPricingPercent: " + pricingPercent);

            sb.Append("\nClerk: " + clerk);
            sb.Append("\nPurchaseOrderNo: " + purchaseOrderNo);
            sb.Append("\nTransactionTotal: " + transactionTotal);
            sb.Append("\nSaleTaxable: " + saleTaxable);
            sb.Append("\nSalesPersonNo: " + salesPersonNo);

            sb.Append("\nTotalSalesTax: " + totalSalesTax);
            sb.Append("\nUnused: " + unused);
            sb.Append("\nInstructions1: " + instructions1);
            sb.Append("\nInstructions2: " + instructions2);
            sb.Append("\nShipToName: " + shipToName);

            sb.Append("\nShipToAddress1: " + shipToAddress1);
            sb.Append("\nShipToAddress2: " + shipToAddress2);
            sb.Append("\nShipToAddress3: " + shipToAddress3);
            sb.Append("\nReferenceInfo: " + referenceInfo);
            sb.Append("\nCustomerTelephone: " + customerTelephone);

            //************************************************

            sb.Append("\nCustomerResaleNo: " + customerResaleNo);
            sb.Append("\nCustomerId: " + customerId);
            sb.Append("\nSpecialOrderVendor: " + specialOrderVendor);
            sb.Append("\nTotalDeposit: " + totalDeposit);
            sb.Append("\nExpectedDeliveryDate: " + expectedDeliveryDate);

            sb.Append("\nExpirationDate: " + expirationDate);
            sb.Append("\nTerminalNo: " + terminalNo);
            sb.Append("\nTransactionNo: " + transactionNo);
            sb.Append("\nTransactionType: " + transactionType);
            sb.Append("\nTotalCashTendered: " + totalCashTendered);

            sb.Append("\nChargeTendered: " + chargeTendered);
            sb.Append("\nChangeGiven: " + changeGiven);
            sb.Append("\nTotalCheckTendered: " + totalCheckTendered);
            sb.Append("\nCheckNo: " + checkNo);
            sb.Append("\nBankCardTendered: " + bankCardTendered);

            sb.Append("\nBankCardNo: " + bankCardNo);
            sb.Append("\nApplyToNo: " + applyToNo);
            sb.Append("\nThirdPartyVendor: " + thirdPartyVendor);
            sb.Append("\nUseESTUcost: " + useESTUcost);
            sb.Append("\nPrivateLabelCardType: " + privateLabelCardType);

            sb.Append("\nSpecialTransactionProcessingFlag: " + specialTransactionProcessingFlag);
            sb.Append("\nPrivateLabelCardPromoType: " + privateLabelCardPromoType);
            sb.Append("\nTdxTransaction: " + tdxTransaction);
            sb.Append("\nUnused2: " + unused2);
            sb.Append("\nDirectShip: " + directShip);

            sb.Append("\nTransactionCodes: " + transactionCodes);
            sb.Append("\nShipViaCode: " + shipViaCode);
            sb.Append("\nRouteNumber: " + routeNumber);
            sb.Append("\nRouteDay: " + routeDay);
            sb.Append("\nRouteStop: " + routeStop);

            sb.Append("\nDeliveryTimeCode: " + deliveryTimeCode);

            return sb.ToString();

        }

        //PRINT CSV HEADER
        public string PrintCsvHeader()
        {
            return recordId + transactionDate + transactionTime + storeNo + customerNo +
                jobNo + taxCode + salesTaxRate + pricingIndicator + pricingPercent +
                clerk + purchaseOrderNo + transactionTotal + saleTaxable + salesPersonNo +
                totalSalesTax + unused + instructions1 + instructions2 + shipToName +
                shipToAddress1 + shipToAddress2 + shipToAddress3 + referenceInfo + customerTelephone +

                //************************

                customerResaleNo + customerId + specialOrderVendor + totalDeposit + expectedDeliveryDate +
                expirationDate + terminalNo + transactionNo + transactionType + totalCashTendered +
                chargeTendered + changeGiven + totalCheckTendered + checkNo + bankCardTendered +
                bankCardNo + applyToNo + thirdPartyVendor + useESTUcost + privateLabelCardType +
                specialTransactionProcessingFlag + privateLabelCardPromoType + tdxTransaction + unused2 + directShip +
                transactionCodes + shipViaCode + routeNumber + routeDay + routeStop +
                deliveryTimeCode;

        }

    }
}
