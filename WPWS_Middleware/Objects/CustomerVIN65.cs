using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPWS_Middleware.Objects
{
    //DEAN JONES
    //JUN.15, 2017
    //CUSTOMER CLASS (VIN65)
    //middleware, with mapper to (CustomerEpicor) object

    //MAPPINGS 
    //  CONSTRUCTOR (Epicor --> VIN65)
    //  METHOD (VIN65(this) --> Epicor)
    //  ---
    //  VIN65 (web service)
    //  XML(proxy object) --> VIN65 (pull data)
    //  VIN65 --> XML(proxy object) (push data)


    class CustomerVIN65
    {
        //VARIABLES (from GetContact VIN65 RESPONSE)
        private string address;
        private string address2;
        private DateTime? birthDate;
        private string city;
        private string company;
        private string contactId;
        private string countryCode;
        private double? customerNumber;
        private DateTime? dateAdded;
        private DateTime? dateModified;
        private string email;
        private string emailStatus;
        private string firstName;
        private bool? isNonTaxable;
        private DateTime? lastLoginDate;
        private string lastName;
        private DateTime? lastOrderDate;
        private double? lifeTimeValue;
        private string masterContactId;
        private double? orderCount;
        private string phone;
        private string sourceCode;
        private string stateCode;
        private string title;
        private string username;
        private string websiteId;
        private string wholeSaleNumber;
        private string zipCode;


        //private string sku;
        //private string title;
        //private double price;
        //private double salePrice;
        //private string productId;
        //private string websiteId;
        //private string brand;
        //private DateTime dateModified;
        //private string type;
        //private string vintage;
        //private bool isActive;

        //GETTERS AND SETTERS 


        //CONSTRUCTOR 

        //TOSTRING (override)

        //METHOD MAPPER TO (CustomerEpicor)

        //--------------------------------------------------------------------------------------------
        //VIN65(CUSTOMER)                                               EAGLE
        //Address	        31 Brightonstone Grove se                   Address 1	    8 copperstone gardens SE
        //Address2                                                      NONE
        //BirthDate	        1983-12-03T08:00:00.000Z                    NONE
        //City calgary                                                  City            calgary
        //Company                                                       NONE
        //ContactID	        69f5ad3f-eb7c-7220-e715-61be435fc1af        NONE
        //CountryCode                                                   NONE
        //CustomerNumber	6595.0				                        Cust #	        600013		
        //DateAdded	        2017-03-01T15:58:58.907Z                    NONE
        //DateModified	    2017-03-01T15:58:58.907Z                    NONE
        //Email             aaroninstallations@gmail.com                Address 2	    brandenkidd @ymail.com
        //EmailStatus       Purchaser                                   NONE
        //FirstName         Aaron                                       Name            BRANDEN KIDD        //(name in one field (eagle))
        //IsNonTaxable	    false				                        NONE
        //LastLoginDate                                                 NONE
        //LastName          Murphy                                      Name            BRANDEN KIDD        //(name in one field (eagle))
        //LastOrderDate	    2017-03-01T15:59:07.000Z                    Last Payment Date
        //LifetimeValue     52.5				                        NONE
        //MasterContactID                                               NONE
        //OrderCount	    1.0				                            NONE
        //Phone	            4038094471				                    Phone           (403) 819-7014		
        //SourceCode                                                    NONE
        //StateCode         AB                                          State           AB
        //Title                                                         NONE
        //Username                                                      NONE
        //WebsiteID	        0e09b01f-f475-900b-ea1d-ab9c1058d706        NONE
        //WholesaleNumber                                               NONE
        //ZipCode           t2z0c6                                      Zip

        //NONE                                                          Customer Type
        //NONE                                                          Salesperson Number
        //NONE                                                          Salesperson Name
        //NONE                                                          Loyalty Level
        //NONE                                                          Loyalty Level Name
        //NONE                                                          Checkbox Selection  FALSE
        //--------------------------------------------------------------------------------------------


    }
}
