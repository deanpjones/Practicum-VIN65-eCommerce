﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vin65WS2.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://webservices.vin65.com/V300/ProductService.cfc")]
        public string vin65WS2_com_vin65_webservicesProduct_ProductServiceService {
            get {
                return ((string)(this["vin65WS2_com_vin65_webservicesProduct_ProductServiceService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://webservices.vin65.com/V301/OrderService.cfc")]
        public string vin65WS2_com_vin65_webservicesOrder_OrderServiceService {
            get {
                return ((string)(this["vin65WS2_com_vin65_webservicesOrder_OrderServiceService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://webservices.vin65.com/V300/InventoryService.cfc")]
        public string vin65WS2_com_vin65_webservicesInventory_InventoryServiceService {
            get {
                return ((string)(this["vin65WS2_com_vin65_webservicesInventory_InventoryServiceService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://webservices.vin65.com/V300/ContactService.cfc")]
        public string vin65WS2_com_vin65_webservicesContact_ContactServiceService {
            get {
                return ((string)(this["vin65WS2_com_vin65_webservicesContact_ContactServiceService"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DeanJonesSANDBOX")]
        public string VIN65WS_Username {
            get {
                return ((string)(this["VIN65WS_Username"]));
            }
            set {
                this["VIN65WS_Username"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("willowpark")]
        public string VIN65WS_Password {
            get {
                return ((string)(this["VIN65WS_Password"]));
            }
            set {
                this["VIN65WS_Password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\_temp")]
        public string XmlPath {
            get {
                return ((string)(this["XmlPath"]));
            }
            set {
                this["XmlPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("#99B6CC")]
        public string ColorPrimary {
            get {
                return ((string)(this["ColorPrimary"]));
            }
            set {
                this["ColorPrimary"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("#3A617F")]
        public string ColorSecondary {
            get {
                return ((string)(this["ColorSecondary"]));
            }
            set {
                this["ColorSecondary"] = value;
            }
        }
    }
}
