using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Model
{
    //DEAN JONES
    //JUL.11, 2017
    //CLASS TO BUILD CSV (FLAT OR FIXED WIDTH FILE)
    //create a flat file (in Epicor's format)
    //FLAT FILE (DETAIL ONLY)

    //SUPPORTING FILES 
    //Model/EpicorCsvFormatting.cs (CSV formatting methods)
    //Model/EpicorCsvHeader.cs (header format)
    //Model/EpicorCsv.cs (combine header and list of details)

    //DJ140BRNXL J140 Carhartt Active Jac Quilted     00000       00001000000636400000636400000000
    //DR02BRN38X34 R02 Carhartt Duck Bib Overall Qu     00000       00001000000636400000636400000000
    //DSHIPPING Shipping and Handling             M  00000       00001000000000000000000000000000

    class EpicorCsvDetail
    {
        //PROPERTIES
        //1-5
        private string recordId;
        private string sku;
        private string itemTransactionType;
        private string description;
        private string taxable;

        //6-10
        private string pricingFlag;
        private string manualPrice;
        private string estimateUseCode;
        private string tradeDiscount;
        private string discountPercent;

        //11-15
        private string specialOrderVendor;
        private string unitOfMeasure;
        private string quantity;
        private string unitPrice;
        private string extendedPrice;

        //16-20
        private string unitCost;
        private string bomSku;
        private string referenceNo;
        private string extendedTaxable;
        private string extendedNonTaxable;

        //21-25
        private string backOrderQuantity;
        private string unused;
        private string termsDiscount;
        private string directShip;
        private string unused2;

        //26-28
        private string exportSetId;
        private string adderSkuFlag;
        private string filler;


        //GETTERS AND SETTERS
        //1-5
        //------------
        public string RecordId { get => recordId; set => recordId = "D".CsvFormatTextPadRight(1, ' '); }                            //x(01) (always 'D')
        public string Sku { get => sku; set => sku = value.CsvFormatTextPadRight(14, ' '); }                                        //x(14)
        public string ItemTransactionType { get => itemTransactionType; set => itemTransactionType = value.CsvFormatTextPadRight(1, ' '); } //x(01)
        public string Description { get => description; set => description = value.CsvFormatTextPadRight(32, ' '); }                //x(32)
        public string Taxable { get => taxable; set => taxable = value.CsvFormatTextPadRight(1, ' '); }                             //x(01)          
        //------------

        //6-10
        //------------
        public string PricingFlag { get => pricingFlag; set => pricingFlag = value.CsvFormatTextPadRight(1, ' '); }                 //x(01)
        public string ManualPrice { get => manualPrice; set => manualPrice = value.CsvFormatTextPadRight(1, ' '); }                 //x(01)
        public string EstimateUseCode { get => estimateUseCode; set => estimateUseCode = value.CsvFormatTextPadRight(1, ' '); }     //x(01)
        public string TradeDiscount { get => tradeDiscount; set => tradeDiscount = value.CsvFormatTextPadRight(1, ' '); }           //x(01)
        //---
        public string DiscountPercent { get => discountPercent; }
        public void SetDiscountPercent(double d) { discountPercent = d.CsvFormatNumberPadLeft(5); }                                 //v9(5) (explicit setter)
        //------------           

        //11-15
        //------------
        public string SpecialOrderVendor { get => specialOrderVendor; set => specialOrderVendor = value.CsvFormatTextPadRight(5, ' '); }    //x(05)
        public string UnitOfMeasure { get => unitOfMeasure; set => unitOfMeasure = value.CsvFormatTextPadRight(2, ' '); }                   //x(02)
        //---
        public string Quantity { get => quantity; }
        public void SetQuantity(double d) { quantity = d.CsvFormatUCurrency(5, 3); }                                                //9(5)v9(3) (explicit setter)
        //---
        public string UnitPrice { get => unitPrice; }
        public void SetUnitPrice(double d) { unitPrice = d.CsvFormatUCurrency(5, 3); }                                              //9(5)v9(3) (explicit setter)
        //---
        public string ExtendedPrice { get => extendedPrice; }
        public void SetExtendedPrice(double d) { extendedPrice = d.CsvFormatUCurrency(6, 2); }                                      //9(6)v9(2) (explicit setter)
        //------------

        //16-20
        //------------
        public string UnitCost { get => unitCost; }
        public void SetUnitCost(double d) { unitCost = d.CsvFormatUCurrency(5, 3); }                                                //9(5)v9(3) (explicit setter)
        //---
        public string BomSku { get => bomSku; set => bomSku = value.CsvFormatTextPadRight(1, ' '); }                                //x(01)
        //---
        public string ReferenceNo { get => referenceNo; }
        public void SetReferenceNo(double d) { referenceNo = d.CsvFormatNumberPadLeft(3); }                                         //9(3) (explicit setter)
        //---
        public string ExtendedTaxable { get => extendedTaxable; }
        public void SetExtendedTaxable(double d) { extendedTaxable = d.CsvFormatUCurrency(7, 3); }                                  //9(7)v9(3) (explicit setter)
        //---
        public string ExtendedNonTaxable { get => extendedNonTaxable; }
        public void SetExtendedNonTaxable(double d) { extendedNonTaxable = d.CsvFormatUCurrency(7, 3); }                            //9(7)v9(3) (explicit setter)
        //------------

        //21-25
        //------------
        public string BackOrderQuantity { get => backOrderQuantity; }
        public void SetBackOrderQuantity(double d) { backOrderQuantity = d.CsvFormatUCurrency(5, 3); }                              //9(5)v9(3)
        //---
        public string Unused { get => unused; set => unused = value.CsvFormatTextPadRight(10, ' '); }                               //x(10)
        public string TermsDiscount { get => termsDiscount; set => termsDiscount = value.CsvFormatTextPadRight(1, ' '); }           //x(01)
        public string DirectShip { get => directShip; set => directShip = value.CsvFormatTextPadRight(1, ' '); }                    //x(01)
        public string Unused2 { get => unused2; set => unused2 = value.CsvFormatTextPadRight(30, ' '); }                            //x(30)
        //------------           

        //26-28
        //------------
        public string ExportSetId { get => exportSetId; set => exportSetId = value.CsvFormatTextPadRight(10, ' '); }                //x(10)
        public string AdderSkuFlag { get => adderSkuFlag; set => adderSkuFlag = value.CsvFormatTextPadRight(1, ' '); }              //x(01)
        public string Filler { get => filler; set => filler = value.CsvFormatTextPadRight(299, ' '); }                              //x(299)
        //------------
            

        //METHOD DEFAULT PROPERTIES
        private void SetDefaultProperties()
        {
            //1-5
            this.recordId = "D".CsvFormatTextPadRight(1, ' ');              //x(01)       //always 'D'
            this.sku = " ".CsvFormatTextPadRight(14, ' ');                  //x(14)
            this.itemTransactionType = " ".CsvFormatTextPadRight(1, ' ');   //x(01)
            this.description = " ".CsvFormatTextPadRight(32, ' ');          //x(32)
            this.taxable = " ".CsvFormatTextPadRight(1, ' ');               //x(01)

            //6-10
            this.pricingFlag = " ".CsvFormatTextPadRight(1, ' ');           //x(01)
            this.manualPrice = " ".CsvFormatTextPadRight(1, ' ');           //x(01)
            this.estimateUseCode = " ".CsvFormatTextPadRight(1, ' ');       //x(01)
            this.tradeDiscount = " ".CsvFormatTextPadRight(1, ' ');         //x(01)
            this.discountPercent = 0d.CsvFormatNumberPadLeft(5);            //v9(5)

            //11-15
            this.specialOrderVendor = " ".CsvFormatTextPadRight(5, ' ');    //x(05)
            this.unitOfMeasure = " ".CsvFormatTextPadRight(2, ' ');         //x(02)
            this.quantity = 0d.CsvFormatUCurrency(5, 3);                    //9(5)v9(3)
            this.unitPrice = 0d.CsvFormatUCurrency(5, 3);                   //9(5)v9(3)
            this.extendedPrice = 0d.CsvFormatUCurrency(6, 2);               //9(6)v9(2)

            //16-20
            this.unitCost = 0d.CsvFormatUCurrency(5, 3);                    //9(5)v9(3)
            this.bomSku = " ".CsvFormatTextPadRight(1, ' ');                //x(01)
            this.referenceNo = 0d.CsvFormatNumberPadLeft(3);                //9(3)
            this.extendedTaxable = 0d.CsvFormatUCurrency(7, 3);             //9(7)v9(3)
            this.extendedNonTaxable = 0d.CsvFormatUCurrency(7, 3);          //9(7)v9(3)

            //21-25
            this.backOrderQuantity = 0d.CsvFormatUCurrency(5, 3);           //9(5)v9(3)
            this.unused = " ".CsvFormatTextPadRight(10, ' ');               //x(10)
            this.termsDiscount = " ".CsvFormatTextPadRight(1, ' ');         //x(01)
            this.directShip = " ".CsvFormatTextPadRight(1, ' ');            //x(01)
            this.unused2 = " ".CsvFormatTextPadRight(30, ' ');              //x(30)

            //26-28
            this.exportSetId = " ".CsvFormatTextPadRight(10, ' ');          //x(10)
            this.adderSkuFlag = " ".CsvFormatTextPadRight(1, ' ');          //x(01)
            this.filler = " ".CsvFormatTextPadRight(299, ' ');              //x(299)

        }

        //CONSTRUCTOR
        public EpicorCsvDetail()
        {
            SetDefaultProperties();
        }

        //TOSTRING OVERRIDE
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //1-5
            sb.Append("\nRecordId: " + recordId);
            sb.Append("\nSku: " + sku);
            sb.Append("\nItemTransactionType: " + itemTransactionType);
            sb.Append("\nDescription: " + description);
            sb.Append("\nTaxable: " + taxable);

            //6-10
            sb.Append("\nPricingFlag: " + pricingFlag);
            sb.Append("\nManualPrice: " + manualPrice);
            sb.Append("\nEstimateUseCode: " + estimateUseCode);
            sb.Append("\nTradeDiscount: " + tradeDiscount);
            sb.Append("\nDiscountPercent: " + discountPercent);

            //11-15
            sb.Append("\nSpecialOrderVendor: " + specialOrderVendor);
            sb.Append("\nUnitOfMeasure: " + unitOfMeasure);
            sb.Append("\nQuantity: " + quantity);
            sb.Append("\nUnitPrice: " + unitPrice);
            sb.Append("\nExtendedPrice: " + extendedPrice);

            //16-20
            sb.Append("\nUnitCost: " + unitCost);
            sb.Append("\nBomSku: " + bomSku);
            sb.Append("\nReferenceNo: " + referenceNo);
            sb.Append("\nExtendedTaxable: " + extendedTaxable);
            sb.Append("\nExtendedNonTaxable: " + extendedNonTaxable);

            //21-25
            sb.Append("\nBackOrderQuantity: " + backOrderQuantity);
            sb.Append("\nUnused: " + unused);
            sb.Append("\nTermsDiscount: " + termsDiscount);
            sb.Append("\nDirectShip: " + directShip);
            sb.Append("\nUnused2: " + unused2);

            //26-28
            sb.Append("\nExportSetId: " + exportSetId);
            sb.Append("\nAdderSkuFlag: " + adderSkuFlag);
            sb.Append("\nFiller: " + filler);

            return sb.ToString();
        }

        //PRINT CSV HEADER
        public string PrintCsvDetail()
        {
                return recordId + sku + itemTransactionType + description + taxable + 
                pricingFlag + manualPrice + estimateUseCode + tradeDiscount + discountPercent + 
                specialOrderVendor + unitOfMeasure + quantity + unitPrice + extendedPrice + 
                unitCost + bomSku + referenceNo + extendedTaxable + extendedNonTaxable + 
                backOrderQuantity + unused + termsDiscount + directShip + unused2 + 
                exportSetId + adderSkuFlag + filler;
        }

    }
}
