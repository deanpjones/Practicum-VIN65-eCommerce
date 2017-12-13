using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WPWS_Middleware.Objects
{
    /// <summary>
    ///     HEADER
    /// </summary>
    /// <remarks>
    ///     DEAN JONES
    ///     JUN.15, 2017
    ///     INVENTORY CLASS (VIN65)
    ///     middleware, with mapper to (InventoryEpicor) object
    /// </remarks>


    /// <summary>
    ///     OVERVIEW
    /// </summary>
    /// <remarks>
    ///     MAPPINGS 
    ///     CONSTRUCTOR (Epicor --> VIN65)
    ///     METHOD (VIN65(this) --> Epicor)
    ///     ---
    ///     VIN65 (web service)
    ///     XML(proxy object) --> VIN65 (pull data)
    ///     VIN65 --> XML(proxy object) (push data)
    /// </remarks>

    /// <summary> Class </summary>
    public class InventoryVIN65
    {
        /// <summary> Variable (Product), brand name </summary>
        private string brand;
        /// <summary> Variable (Product), date modified (is nullable) </summary>
        private DateTime? dateModified;
        /// <summary> Variable (Product), price of product (is nullable) </summary>
        private double? price;
        /// <summary> Variable (Product), product Id </summary>
        private string productId;
        /// <summary> Variable (Product), SKU number of product </summary>
        private string sku;
        /// <summary> Variable (Product), sale price (is nullable) </summary>
        private double? salePrice;
        /// <summary> Variable (Product), title </summary>
        private string title;
        /// <summary> Variable (Product), product type </summary>
        private string type;
        /// <summary> Variable (Product), vintage </summary>
        private string vintage;
        /// <summary> Variable (Product), website Id </summary>
        private string websiteId;
        /// <summary> Variable (Product), is the product active (is nullable) </summary>
        private bool? isActive;
        /// <summary>   Variable (Inventory), current inventory number (is nullable) </summary>
        private double? currentInventory;
        /// <summary>   Variable (Inventory), inventory pool </summary>
        private string inventoryPool;
        /// <summary>   Variable (Inventory), inventory pool Id </summary>
        private string inventoryPoolId;
        //private string sku;               //redundant
        //private string websiteId;         //redundant

        /// <summary>   Getters and Setters, Brand </summary>
        public string Brand { get => brand; set => brand = value; }
        /// <summary>   Getters and Setters, Date modified </summary>
        public DateTime? DateModified { get => dateModified; set => dateModified = value; }
        /// <summary>   Getters and Setters, Price </summary>
        public double? Price { get => price; set => price = value; }
        /// <summary>   Getters and Setters, Product Id </summary>
        public string ProductId { get => productId; set => productId = value; }
        /// <summary>   Getters and Setters, SKU number </summary>
        public string Sku { get => sku; set => sku = value; }
        /// <summary>   Getters and Setters, Sale price </summary>
        public double? SalePrice { get => salePrice; set => salePrice = value; }
        /// <summary>   Getters and Setters, Title </summary>
        public string Title { get => title; set => title = value; }
        /// <summary>   Getters and Setters, Product type </summary>
        public string Type { get => type; set => type = value; }
        /// <summary>   Getters and Setters, Vintage </summary>
        public string Vintage { get => vintage; set => vintage = value; }
        /// <summary>   Getters and Setters, Website Id </summary>
        public string WebsiteId { get => websiteId; set => websiteId = value; }
        /// <summary>   Getters and Setters, Is product active </summary>
        public bool? IsActive { get => isActive; set => isActive = value; }
        //---
        /// <summary>   Getters and Setters, Current inventory </summary>
        public double? CurrentInventory { get => currentInventory; set => currentInventory = value; }
        /// <summary>   Getters and Setters, Inventory pool </summary>
        public string InventoryPool { get => inventoryPool; set => inventoryPool = value; }
        /// <summary>   Getters and Setters, Inventory pool Id </summary>
        public string InventoryPoolId { get => inventoryPoolId; set => inventoryPoolId = value; }

        /// <summary> Constructor </summary>
        public InventoryVIN65() { }

        /// <summary> Constructor (by SKU) </summary>
        /// <param name="sku"> Provide the SKU number </param>
        public InventoryVIN65(string sku)
        {
            this.sku = sku;
        }

        /// <summary>
        ///     CONSTRUCTOR (taking (InventoryEpicor) object to convert) <para />
        ///     MAPPING (EPICOR to VIN65) <para />
        ///     MAPPING (InventoryEpicor to InventoryVIN65)
        /// </summary>
        /// <param name="inventoryEpicor">This constructor accepts a parameter to be converted to THIS object</param>
        public InventoryVIN65(InventoryEpicor inventoryEpicor)
        {
            this.sku = inventoryEpicor.Sku;
            this.title = inventoryEpicor.Description;
            this.price = inventoryEpicor.Retail;

            //these properties (cannot be mapped)(leave blank)
            //this.salePrice = null;
            //this.ProductId = null;
            //this.websiteId = null;
            //this.brand = null;
            //this.dateModified = null;
            //this.type = null;
            //this.vintage = null;
            //this.isActive = null;

            this.currentInventory = inventoryEpicor.Qoh;
        }

        /// <summary>
        ///     METHOD InventoryVIN65ToEpicor (taking (this) object to convert) <para />
        ///     MAPPING (VIN65 to EPICOR) <para />
        ///     MAPPING (InventoryVIN65 to InventoryEpicor)
        /// </summary>
        /// <returns> This method converts THIS object and RETURNS another object type </returns>
        public InventoryEpicor InventoryVIN65ToEpicor()
        {
            InventoryEpicor ie = new InventoryEpicor(this);
            return ie;
        }

        /// <summary> ToString (override) </summary>
        /// <returns> Returns a string of all the properties </returns>
        public override string ToString()
        {
            return
                brand + ", " +
                ((object)dateModified ?? "") + ", " +
                ((object)price ?? "") + ", " +
                productId + ", " +
                sku + ", " +
                ((object)salePrice ?? "") + ", " +
                title + ", " +
                type + ", " +
                vintage + ", " +
                websiteId + ", " +
                ((object)isActive ?? "") + ", " +

                ((object)currentInventory ?? "") + ", " +
                inventoryPool + ", " +
                inventoryPoolId;

        }

        /// <summary> Other Info </summary>
        /// <remarks>
        /// --------------------------------------------------------------------------------------------
        /// MAPPING
        /// VIN65                                                                   EAGLE
        /// SKU	                20161122a                                           SKU	            20161122A
        /// Title               A Night in Spain with Winemaker Nathalie Bonhomme   Description     A Night in Spain Winemaker Nat B
        /// Price	            25.0			                                    Retail	        23.81
        /// SalePrice                                                               NONE
        /// ProductID	        1bbd8f1f-e467-9adb-4d39-5ca7424ff1ee                NONE
        /// Website	            0e09b01f-f475-900b-ea1d-ab9c1058d706                NONE
        /// Brand                                                                   NONE
        /// DateModified	    2016-11-10T19:08:35.997Z                            NONE
        /// Type EventTicket                                                        NONE
        /// Vintage                                                                 NONE
        /// isActive	true			                                            NONE
        /// NONE                                                                    Loc
        /// NONE                                                                    Dept #	        T
        /// NONE                                                                    Attr 1 Value+	EACH
        /// NONE                                                                    UPC
        /// CurrentInventory	17.0			                                    QOH	            29
        /// NONE                                                                    QOO	            0
        /// NONE                                                                    Committed Qty	0
        /// CurrentInventory	17.0			                                    Qty Available	29
        /// NONE                                                                    Primary Vendor  TIC01
        /// NONE                                                                    Mfg Vendor
        /// NONE                                                                    Mfg Part #	
        /// NONE                                                                    Fineline #	    TASTG
        /// --------------------------------------------------------------------------------------------
        /// </remarks>


        /// <remarks>
        /// https://webservices.vin65.com/V300/ProductService.cfc?wsdl
        /// <complexType name = "Product" >
        /// <sequence>
        /// <element name="Brand" nillable="true" type="xsd:string"/>
        /// <element name = "DateModified" nillable="true" type="xsd:dateTime"/>
        /// <element name = "Price" nillable="true" type="xsd:double"/>
        /// <element name = "ProductID" nillable="true" type="xsd:string"/>
        /// <element name = "SKU" nillable="true" type="xsd:string"/>
        /// <element name = "SalePrice" nillable="true" type="xsd:double"/>
        /// <element name = "Title" nillable="true" type="xsd:string"/>
        /// <element name = "Type" nillable="true" type="xsd:string"/>
        /// <element name = "Vintage" nillable="true" type="xsd:double"/>
        /// <element name = "WebsiteID" nillable="true" type="xsd:string"/>
        /// <element name = "isActive" nillable="true" type="xsd:boolean"/>
        /// </sequence>
        /// </complexType>
        /// </remarks>

        /// <remarks>
        /// INVENTORY
        /// https://webservices.vin65.com/V300/InventoryService.cfc?wsdl
        /// <sequence>
        /// <element name = "CurrentInventory" nillable="true" type="xsd:double"/>
        /// <element name = "InventoryPool" nillable="true" type="xsd:string"/>
        /// <element name = "InventoryPoolID" nillable="true" type="xsd:string"/>
        /// <element name = "SKU" nillable="true" type="xsd:string"/>
        /// <element name = "WebsiteID" nillable="true" type="xsd:string"/>
        /// </sequence>
        /// </remarks>
    }
}
