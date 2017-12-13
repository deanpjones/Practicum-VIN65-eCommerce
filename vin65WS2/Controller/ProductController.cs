using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using vin65WS.Controller;
using VinProduct = vin65WS2.com.vin65.webservicesProduct;       //access the methods directly (instead of using proxy files)

namespace vin65WS2
{
    //DEAN JONES
    //MAY 30, 2017
    //ProductController.cs
    //handles all the METHODS for making calls related to PRODUCTS

    //SUPPORTING FILES 
    //  Proxy/ProductServiceService.cs (proxy class)(generated from wsdl.exe)

    //TODO
    //BACKUP ALL (EACH PRODUCT, all details)(in case need to restore...)
    //FIX, GetProductDetailsBySKU, GetProductDetailsBySKU2 (NOT WORKING, may be a bug)(Erin moving me on to inventory, don't have time...)
    //finish, PS_AddUpdateProductBySKU2...


    public class ProductController
    {
        //OBJECTS
        MyConnection conn;                  //to connect with username and password
        VinProduct.ProductServiceService ps;        //connect to (Product Service)
        //------
        //SEARCH PRODUCTS
        VinProduct.Request1 ps_request1;
        private VinProduct.Response1 ps_response1;
        //VinProduct.Security ps_security;
        //------
        //GET PRODUCT DETAILS
        VinProduct.Request3 ps_request3;
        private VinProduct.Response3 ps_response3;
        //------
        //ADD or UPDATE PRODUCT DETAILS
        VinProduct.Request2 ps_request2;
        private VinProduct.Response2 ps_response2;


        //CONSTRUCTOR
        public ProductController(string username, string password)
        {
            //INSTANTIATE OBJECTS
            conn = new MyConnection(username, password);    //Establish a connection when an object is created
            ps = new VinProduct.ProductServiceService();            //create PRODUCT SERVICES object

            //--------------
            //SEARCH PRODUCT
            ps_request1 = new VinProduct.Request1();                 //create REQUEST object
            ps_request1.Security = new VinProduct.Security();        //Security settings for connection (to VIN65 web service)
            ps_response1 = new VinProduct.Response1();               //create RESPONSE object (array of Products[...])

            //SET USERNAME and PASSWORD
            ps_request1.Security.Username = conn.Ws_Username;        //set global username
            //ps_request.Security.Username = "DeanJonesSANDBOX";
            ps_request1.Security.Password = conn.Ws_Password;        //set global password
            //ps_request.Security.Password = "willowpark";
            //--------------

            //-------------------
            //GET PRODUCT DETAILS
            ps_request3 = new VinProduct.Request3();                 //create REQUEST object
            ps_request3.Security = new VinProduct.Security();        //Security settings for connection (to VIN65 web service)
            ps_response3 = new VinProduct.Response3();               //create RESPONSE object (array of Products[...])

            //SET USERNAME and PASSWORD
            ps_request3.Security.Username = conn.Ws_Username;        //set global username
            ps_request3.Security.Password = conn.Ws_Password;        //set global password
            //-------------------

            //-----------------------------
            //ADD OR UPDATE PRODUCT DETAILS
            ps_request2 = new VinProduct.Request2();                 //create REQUEST object
            ps_request2.Security = new VinProduct.Security();        //Security settings for connection (to VIN65 web service)
            ps_response2 = new VinProduct.Response2();               //create RESPONSE object (array of Products[...])
            
            //SET USERNAME and PASSWORD
            ps_request2.Security.Username = conn.Ws_Username;        //set global username
            ps_request2.Security.Password = conn.Ws_Password;        //set global password
            //-----------------------------
        }

        //GETTERS AND SETTERS
        public VinProduct.Response1 Ps_response1 { get => ps_response1; }
        public VinProduct.Response3 Ps_response3 { get => ps_response3; }
        public VinProduct.Response2 Ps_response2 { get => ps_response2; }

        //public VinProduct.Response1 VinProduct.Response
        //{
        //    get { return ps_response1; }
        //}

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //METHOD (DISPLAY PROPERTIES)(SHORT DESCRIPTION)
        public string PS_DisplayProductDetailsShort(VinProduct.Product product)
        {
            StringBuilder sb = new StringBuilder();
            //product title...
            sb.Append("PRODUCT (sku:" + product.SKUs[0].SKU1 + ")");
            sb.Append("\n-----------------------------------------");           //beginning of properties

            sb.Append("\nProductID: " + product.ProductID);

            sb.Append("\nSKUs...");
            sb.Append("\n   Inventory...");
            sb.Append("\n      CurrentInventory: " + product.SKUs[0].Inventory[0].CurrentInventory);
            sb.Append("\n      InventoryPool: " + product.SKUs[0].Inventory[0].InventoryPool);
            sb.Append("\n   Prices...");
            sb.Append("\n      Price1:" + product.SKUs[0].Prices[0].Price1);
            sb.Append("\n      PriceLevel:" + product.SKUs[0].Prices[0].PriceLevel);
            sb.Append("\n      PriceQuantity:" + product.SKUs[0].Prices[0].PriceQuantity);
            sb.Append("\n      SalePrice:" + product.SKUs[0].Prices[0].SalePrice);
            sb.Append("\n   SKU1: " + product.SKUs[0].SKU1);
            sb.Append("\n   UnitDescription: " + product.SKUs[0].UnitDescription);
            sb.Append("\n   Weight: " + product.SKUs[0].Weight);

            sb.Append("\nSubTitle: " + product.SubTitle);

            sb.Append("\nWineProperties...");
            sb.Append("\n   BottlesInCase: " + product.WineProperties.BottlesInCase);
            sb.Append("\n   BottleSize: " + product.WineProperties.BottleSize);
            sb.Append("\n   BottleSizeInML: " + product.WineProperties.BottleSizeInML);

            sb.Append("\nTitle: " + product.Title);
            sb.Append("\nWebsiteID: " + product.WebsiteID);

            sb.Append("\n-----------------------------------------");           //end of properties

            return sb.ToString();
        }

        //METHOD (DISPLAY ALL PRODUCT DETAILS)(LONG DESCRIPTION)(~84 properites) 
        public string PS_DisplayProductDetailsLong(VinProduct.Product product)
        {              
            StringBuilder sb = new StringBuilder();
            //product title...
            sb.Append("PRODUCT (sku:" + product.SKUs[0].SKU1 + ")");
            sb.Append("\n-----------------------------------------");         //beginning of properties

            sb.Append("\nActionMessage: " + product.ActionMessage);
            sb.Append("\nBrand: " + product.Brand);
            sb.Append("\nBundleItems: " + product.BundleItems);
            sb.Append("\nDateAdded: " + product.DateAdded);
            sb.Append("\nDateModified: " + product.DateModified);

            //<Product xsi:type="ns4:Product" xmlns:ns4="http://_product.product.V300">
            //        <ActionMessage xsi:type="xsd:string"></ActionMessage>
            //        <Brand xsi:type="xsd:string"></Brand>
            //        <BundleItems xsi:type="soapenc:Array" xsi:nil="true" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"/>
            //        <DateAdded xsi:type="xsd:dateTime">2017-06-27T17:25:29.327Z</DateAdded>
            //        <DateModified xsi:type="xsd:dateTime">2017-06-29T17:42:28.187Z</DateModified>

            sb.Append("\nDescription");
            sb.Append("\n   Description1: " + product.Description.Description1);
            sb.Append("\n   Teaser: " + product.Description.Teaser);

            //        <Description xsi:type="ns4:Description">
            //            <Description xsi:type="xsd:string"></Description>
            //            <Teaser xsi:type="xsd:string"></Teaser>
            //        </Description>

            sb.Append("\nIsActive: " + product.IsActive);
            sb.Append("\nIsDisplayOnWebsite: " + product.IsDisplayOnWebsite);

            //        <IsActive xsi:type="xsd:boolean">false</IsActive>
            //        <IsDisplayOnWebsite xsi:type="xsd:boolean">false</IsDisplayOnWebsite>

            sb.Append("\nMedia...");
            if (product.Media.Length != 0)   //IF there is Media (IndexOutOfRangeException)
            {
                sb.Append("\n   Caption: " + product.Media[0].Caption);             
                sb.Append("\n   DisplayOrder: " + product.Media[0].DisplayOrder);
                sb.Append("\n   File: " + product.Media[0].File);
                sb.Append("\n   Thumbnail: " + product.Media[0].Thumbnail);
                sb.Append("\n   Title: " + product.Media[0].Title);
                sb.Append("\n   Type: " + product.Media[0].Type);
            }

            //        <Media soapenc:arrayType="ns4:Media[0]" xsi:type="soapenc:Array" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"/>

            sb.Append("\nPOSTitle: " + product.POSTitle);

            sb.Append("\nPhotos...");
            if (product.Photos.Length != 0)   //IF there is Photos (IndexOutOfRangeException)
            {
                sb.Append("\n   Caption: " + product.Photos[0].Caption);
                sb.Append("\n   DisplayOrder: " + product.Photos[0].DisplayOrder);
                sb.Append("\n   Photo1: " + product.Photos[0].Photo1);
                sb.Append("\n   Title: " + product.Photos[0].Title);
            }

            //        <POSTitle xsi:type="xsd:string"></POSTitle>
            //        <Photos soapenc:arrayType="ns4:Photo[0]" xsi:type="soapenc:Array" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"/>

            sb.Append("\nProductID: " + product.ProductID);

            //        <ProductID xsi:type="xsd:string">29ddb9b6-cd97-dd8a-694b-0ca4de93d49a</ProductID>

            sb.Append("\nSKUs...");
            sb.Append("\n   CostOfGood: " + product.SKUs[0].CostOfGood);
            sb.Append("\n   DisplayOrder: " + product.SKUs[0].DisplayOrder);

            sb.Append("\n   Inventory...");
            sb.Append("\n      CurrentInventory: " + product.SKUs[0].Inventory[0].CurrentInventory);
            sb.Append("\n      InventoryPool: " + product.SKUs[0].Inventory[0].InventoryPool);

            sb.Append("\n   IsInventoryOn: " + product.SKUs[0].IsInventoryOn);
            sb.Append("\n   IsNoShippingCharge: " + product.SKUs[0].IsNoShippingCharge);
            sb.Append("\n   IsNonTaxable: " + product.SKUs[0].IsNonTaxable);
            sb.Append("\n   MaxOrderQty: " + product.SKUs[0].MaxOrderQty);
            sb.Append("\n   MinOrderQty: " + product.SKUs[0].MinOrderQty);
            sb.Append("\n   OrderInMultiplesOf: " + product.SKUs[0].OrderInMultiplesOf);

            sb.Append("\n   Prices...");
            sb.Append("\n      Price1:" + product.SKUs[0].Prices[0].Price1);
            sb.Append("\n      PriceLevel:" + product.SKUs[0].Prices[0].PriceLevel);
            sb.Append("\n      PriceQuantity:" + product.SKUs[0].Prices[0].PriceQuantity);
            sb.Append("\n      SalePrice:" + product.SKUs[0].Prices[0].SalePrice);

            //        <SKUs soapenc:arrayType="ns4:SKU[1]" xsi:type="soapenc:Array" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/">
            //            <SKUs xsi:type="ns4:SKU">
            //                <CostOfGood xsi:type="xsd:double">0.0</CostOfGood>
            //                <DisplayOrder xsi:type="xsd:double">1.0</DisplayOrder>
            //                <Inventory soapenc:arrayType="ns4:Inventory[1]" xsi:type="soapenc:Array">
            //                    <Inventory xsi:type="ns4:Inventory">
            //                        <CurrentInventory xsi:type="xsd:double">33.0</CurrentInventory>
            //                        <InventoryPool xsi:type="xsd:string">Default Inventory Pool</InventoryPool>
            //                    </Inventory>
            //                </Inventory>
            //                <IsInventoryOn xsi:type="xsd:boolean">true</IsInventoryOn>
            //                <IsNoShippingCharge xsi:type="xsd:boolean">false</IsNoShippingCharge>
            //                <IsNonTaxable xsi:type="xsd:boolean">false</IsNonTaxable>
            //                <MaxOrderQty xsi:type="xsd:double" xsi:nil="true"/>
            //                <MinOrderQty xsi:type="xsd:double" xsi:nil="true"/>
            //                <OrderInMultiplesOf xsi:type="xsd:double" xsi:nil="true"/>
            //                <Prices soapenc:arrayType="ns4:Price[1]" xsi:type="soapenc:Array">
            //                    <Prices xsi:type="ns4:Price">
            //                        <Price xsi:type="xsd:double">0.0</Price>
            //                        <PriceLevel xsi:type="xsd:string">Retail</PriceLevel>
            //                        <PriceQuantity xsi:type="xsd:double">1.0</PriceQuantity>
            //                        <SalePrice xsi:type="xsd:double">0.0</SalePrice>
            //                    </Prices>
            //                </Prices>

            sb.Append("\n   SKU1: " + product.SKUs[0].SKU1);
            sb.Append("\n   UPCCode: " + product.SKUs[0].UPCCode);
            sb.Append("\n   UnitDescription: " + product.SKUs[0].UnitDescription);
            sb.Append("\n   Weight: " + product.SKUs[0].Weight);

            //                <SKU xsi:type="xsd:string">746969c</SKU>
            //                <UPCCode xsi:type="xsd:string"></UPCCode>
            //                <UnitDescription xsi:type="xsd:string">1 bottle</UnitDescription>
            //                <Weight xsi:type="xsd:double">0.0</Weight>
            //            </SKUs>
            //        </SKUs>

            sb.Append("\nSpiritProperties: " + product.SpiritProperties);
            sb.Append("\nSubTitle: " + product.SubTitle);
            sb.Append("\nTitle: " + product.Title);

            sb.Append("\nVintageNotes...");
            if (product.VintageNotes.Length != 0)   //IF there is any VintageNotes (IndexOutOfRangeException)
            {
                sb.Append("\n   Note: " + product.VintageNotes[0].Note);
                sb.Append("\n   Vintage: " + product.VintageNotes[0].Vintage);
            }

            sb.Append("\nWebsiteID: " + product.WebsiteID);

            //        <SpiritProperties xsi:type="ns4:SpiritProperties" xsi:nil="true"/>
            //        <SubTitle xsi:type="xsd:string"></SubTitle>
            //        <Title xsi:type="xsd:string">666 Crimes Shiraz Durif Red Blend</Title>
            //        <Type xsi:type="xsd:string">Wine</Type>
            //        <VintageNotes soapenc:arrayType="ns4:VintageNote[0]" xsi:type="soapenc:Array" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"/>
            //        <WebsiteID xsi:type="xsd:string">8d4e8ba9-c5fe-77f4-9d7f-127f3ae38b53</WebsiteID>

            sb.Append("\nWineProperties...");
            sb.Append("\n   Acid: " + product.WineProperties.Acid);
            sb.Append("\n   Alcohol: " + product.WineProperties.Alcohol);
            sb.Append("\n   Appellation: " + product.WineProperties.Appellation);
            sb.Append("\n   AvgRating: " + product.WineProperties.AvgRating);
            sb.Append("\n   Awards: " + product.WineProperties.Awards);
            sb.Append("\n   BottlesInCase: " + product.WineProperties.BottlesInCase);
            sb.Append("\n   BottleSize: " + product.WineProperties.BottleSize);
            sb.Append("\n   BottleSizeInML: " + product.WineProperties.BottleSizeInML);
            sb.Append("\n   BottlingDate: " + product.WineProperties.BottlingDate);
            sb.Append("\n   CGRating: " + product.WineProperties.CGRating);
            sb.Append("\n   Fermentation: " + product.WineProperties.Fermentation);
            sb.Append("\n   FoodPairingNotes: " + product.WineProperties.FoodPairingNotes);
            sb.Append("\n   HarvestDate: " + product.WineProperties.HarvestDate);
            sb.Append("\n   JHRating: " + product.WineProperties.JHRating);
            sb.Append("\n   OtherNotes: " + product.WineProperties.OtherNotes);
            sb.Append("\n   PH: " + product.WineProperties.PH);
            sb.Append("\n   Production: " + product.WineProperties.Production);
            sb.Append("\n   ProductionNotes: " + product.WineProperties.ProductionNotes);
            sb.Append("\n   Ratings: " + product.WineProperties.Ratings);
            sb.Append("\n   Region: " + product.WineProperties.Region);
            sb.Append("\n   ResidualSugar: " + product.WineProperties.ResidualSugar);
            sb.Append("\n   RPRating: " + product.WineProperties.RPRating);
            sb.Append("\n   STRating: " + product.WineProperties.STRating);
            sb.Append("\n   Sugar: " + product.WineProperties.Sugar);
            sb.Append("\n   Tannin: " + product.WineProperties.Tannin);
            sb.Append("\n   TastingNotes: " + product.WineProperties.TastingNotes);
            sb.Append("\n   Type: " + product.WineProperties.Type);
            sb.Append("\n   Varietal: " + product.WineProperties.Varietal);
            sb.Append("\n   VineyardDesignation: " + product.WineProperties.VineyardDesignation);
            sb.Append("\n   VineyardNotes: " + product.WineProperties.VineyardNotes);
            sb.Append("\n   Vintage: " + product.WineProperties.Vintage);
            sb.Append("\n   WAndSRating: " + product.WineProperties.WAndSRating);
            sb.Append("\n   WARating: " + product.WineProperties.WARating);
            sb.Append("\n   WBRating: " + product.WineProperties.WBRating);
            sb.Append("\n   WERating: " + product.WineProperties.WERating);
            sb.Append("\n   WineMakerNotes: " + product.WineProperties.WineMakerNotes);
            sb.Append("\n   WNRating: " + product.WineProperties.WNRating);
            sb.Append("\n   WSRating: " + product.WineProperties.WSRating);

            //        <WineProperties xsi:type="ns4:WineProperties">
            //            <Acid xsi:type="xsd:string"></Acid>
            //            <Alcohol xsi:type="xsd:string"></Alcohol>
            //            <Appellation xsi:type="xsd:string"></Appellation>
            //            <AvgRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <Awards xsi:type="xsd:string"></Awards>
            //            <BottleSize xsi:type="xsd:string">750 ml</BottleSize>
            //            <BottleSizeInML xsi:type="xsd:double">750.0</BottleSizeInML>
            //            <BottlesInCase xsi:type="xsd:double" xsi:nil="true"/>
            //            <BottlingDate xsi:type="xsd:string"></BottlingDate>
            //            <CGRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <Fermentation xsi:type="xsd:string"></Fermentation>
            //            <FoodPairingNotes xsi:type="xsd:string"></FoodPairingNotes>
            //            <HarvestDate xsi:type="xsd:string"></HarvestDate>
            //            <JHRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <OtherNotes xsi:type="xsd:string"></OtherNotes>
            //            <PH xsi:type="xsd:string"></PH>
            //            <Production xsi:type="xsd:string"></Production>
            //            <ProductionNotes xsi:type="xsd:string"></ProductionNotes>
            //            <RPRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <Ratings xsi:type="xsd:string"></Ratings>
            //            <Region xsi:type="xsd:string"></Region>
            //            <ResidualSugar xsi:type="xsd:string"></ResidualSugar>
            //            <STRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <Sugar xsi:type="xsd:string"></Sugar>
            //            <Tannin xsi:type="xsd:string"></Tannin>
            //            <TastingNotes xsi:type="xsd:string"></TastingNotes>
            //            <Type xsi:type="xsd:string"></Type>
            //            <Varietal xsi:type="xsd:string"></Varietal>
            //            <VineyardDesignation xsi:type="xsd:string"></VineyardDesignation>
            //            <VineyardNotes xsi:type="xsd:string"></VineyardNotes>
            //            <Vintage xsi:type="xsd:double" xsi:nil="true"/>
            //            <WARating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WAndSRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WBRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WERating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WNRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WSRating xsi:type="xsd:double" xsi:nil="true"/>
            //            <WineMakerNotes xsi:type="xsd:string"></WineMakerNotes>
            //        </WineProperties>
            //    </Product>

            sb.Append("\n-----------------------------------------");     //end of properties

            return sb.ToString();
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //METHOD (ADD/UPDATE)(PRODUCT object)(returns Response2)
        //(same as GetProductDetailsBySKU, but RETURN OBJECT is ONE LEVEL HIGHER)(gives IsSuccessful, Errors, RecordCount properties)
        //*** warning, may need to run GetProductDetails first, to (fill in the blank fields) of existing product, so we don't overwrite ***
        public VinProduct.Response2 PS_AddUpdateProduct(VinProduct.Product myproduct)
        {
            //*** see constructor for instantiated objects... ***

            //MODE (ps_request2.Mode)
            //'CreateAttributes' (some properties) will be created on the fly. 
            //'Strict' (some properties) must exist or add/update will error.
            //< ErrorCode xsi: type = "xsd:string" > InvalidMode </ ErrorCode >
            //< ErrorMessage xsi: type = "xsd:string" > Mode must be one of Strict,CreateAttributes </ ErrorMessage >
            //
            //WebsiteID, ProductID, Region (in Strict Mode...)(if these are removed it will create object...)

            //check if PRODUCT already exists...(ProductID...)
            //add new product OR update existing...?
            //

            try
            {
                //set mode
                ps_request2.Mode = "Strict";                //'Strict' (some properties) must exist or add/update will error.
                //******************************
                //add (Product object) to request
                ps_request2.Product = myproduct;            //need to provide a (Product object)(use GetMethod...)
                //*******************************
                //ps_request2.Security                      //already set in constructor

                //********************************************
                ps_response2 = ps.AddUpdateProductDetail(ps_request2);
                //********************************************
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ps_response2;
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //METHOD (GET PRODUCT DETAILS)(PRODUCT object)(returns Product)
        public VinProduct.Product PS_GetProductDetailsBySKU(string sku)
        {
            //*** see constructor for instantiated objects... ***

            //Create a PRODUCT 
            VinProduct.Product product = new VinProduct.Product();

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                ps_request3.SKU = sku;
                //********************************************
                //"There is an error in XML document (99, 15)."
                ps_response3 = ps.GetProductDetail(ps_request3);
                //********************************************

                //TEST IF THE QUERY WAS SUCCESSFUL
                if ((bool)ps_response3.IsSuccessful)
                {
                    product = ps_response3.Product;
                    //product = ps_response3.Products[0];
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }

            return product;
        }

        //METHOD (GET PRODUCT DETAILS)(PRODUCT object)(returns Response3)
        //(same as GetProductDetailsBySKU, but RETURN OBJECT is ONE LEVEL HIGHER)(gives IsSuccessful, Errors, RecordCount properties)
        public VinProduct.Response3 PS_GetProductDetailsBySKU2(string sku)
        {
            //*** see constructor for instantiated objects... ***

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                ps_request3.SKU = sku;
                //ps_request3.WebsiteID = "8d4e8ba9-c5fe-77f4-9d7f-127f3ae38b53";
                //********************************************
                //????????????
                //{"Cannot assign object of type System.Xml.XmlNode[] to an object of type VinProduct.Product."}
                //may have hit a KNOWN BUG 
                //  https://social.msdn.microsoft.com/Forums/en-US/f550e2b2-af9e-4653-a618-cffffdc70fdf/cannot-assign-object-of-type-systemxmlxmlnode-to-an-object-of-type-systemstring-calling-a?forum=asmxandxml

                ps_response3 = ps.GetProductDetail(ps_request3);
                //********************************************
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ps_response3;
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************      

        //METHOD (SEARCH FOR A PRODUCT)(PRODUCT object)(returns Product1)
        public VinProduct.Product1 PS_SearchProductBySKU(string sku)
        {
            //*** see constructor for instantiated objects... ***

            //Create a PRODUCT 
            VinProduct.Product1 product1 = new VinProduct.Product1();

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                ps_request1.SKU = sku;
                //********************************************
                ps_response1 = ps.SearchProducts(ps_request1);
                //********************************************

                //TEST IF THE QUERY WAS SUCCESSFUL
                if ((bool)ps_response1.IsSuccessful)
                {                   
                    product1 = ps_response1.Products[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product1;
        }

        //METHOD (SEARCH FOR A PRODUCT)(PRODUCT object)(returns Response1)
        //(same as VinProduct.SearchProductBySKU, but RETURN OBJECT is ONE LEVEL HIGHER)(gives IsSuccessful, Errors, RecordCount properties)
        public VinProduct.Response1 PS_SearchProductBySKU2(string sku)
        {
            //*** see constructor for instantiated objects... ***

            try
            {
                //request.SKU = "739242";                     //set the SKU to search for...
                ps_request1.SKU = sku;
                //********************************************
                ps_response1 = ps.SearchProducts(ps_request1);
                //********************************************
                //System.InvalidOperationException: 'There is an error in XML document (5, 6).'
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ps_response1;
        }

        //METHOD (SEARCH FOR ALL PRODUCTS)(PRODUCT object)(returns List<Product1>)
        public List<VinProduct.Product1> PS_SearchAllProducts()
        {
            //*** see constructor for instantiated objects... ***

            //create a list of PRODUCTS
            List<VinProduct.Product1> products = new List<VinProduct.Product1>();

            try
            {
                //********************************************
                //TO CALL (ONE PRODUCT)(omit to call ALL PRODUCTS)
                ps_response1 = ps.SearchProducts(ps_request1);
                //********************************************

                //TEST IF THE QUERY WAS SUCCESSFUL
                if ((bool)ps_response1.IsSuccessful)
                {
                    for (int i = 0; i < ps_response1.RecordCount; i++)
                    {
                        products.Add(ps_response1.Products[i]);  //add each product to (list)
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }

        //METHOD (SEARCH FOR ALL PRODUCTS)(PRODUCT object)(returns Response1)
        //(same as VinProduct.SearchAllProducts, but RETURN OBJECT is ONE LEVEL HIGHER)(gives IsSuccessful, Errors, RecordCount properties)
        public VinProduct.Response1 PS_SearchAllProducts2()
        {
            //*** see constructor for instantiated objects... ***

            try
            {
                //********************************************
                //to call (one product)(omit to call all products)
                ps_response1 = ps.SearchProducts(ps_request1);
                //********************************************
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ps_response1;
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //??????????????????????
        //METHOD (push product data back to VIN65)
        public void PushProductEpicorToVin65()
        {
            //??????????
            //DO (GetProductDetailsBySKU) before PUSH UPDATE (otherwise may blank out info in the system)

            //public VinProduct.Response2 AddUpdateProductDetail(VinProduct.Request2 Request) {

            VinProduct.ProductServiceService pss = new VinProduct.ProductServiceService();
            //need VinProduct.Request2 object to pass to method...
            VinProduct.Request2 request = new VinProduct.Request2();
            Product product = new Product();
            //product.
            //request.Mode;
            //request.Product;        //product object
            //request.Security;       //security info?(username? password?)


            //pss.AddUpdateProductDetail();
        }
        //??????????????????????

        ////CREATE XML FROM (LIST OF PRODUCTS)
        //public void PS_ProductToXmlFile(VinProduct.Product1 product)
        //{
        //    XmlSerializer xs = new XmlSerializer(typeof(VinProduct.Product1));

        //    //DATE 
        //    DateTime date = DateTime.Now;
        //    //string date_format = "yyyyMMdd";
        //    string date_format = "yyyyMMdd_hhmm";   //DATE: year/month/day_hours/seconds
        //    //XML PATH
        //    string path = @"c:\_temp\response" + date.ToString(date_format) + ".xml";


        //    TextWriter tw = new StreamWriter(path);
        //    xs.Serialize(tw, product);
        //}


    }
}
