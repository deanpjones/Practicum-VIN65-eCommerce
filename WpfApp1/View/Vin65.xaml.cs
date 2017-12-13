using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;
//using Xceed.Wpf.Toolkit;
using vin65WS2;
using vin65WS2.Controller;
using WpfApp1.Properties;
using WpfApp1.View;
using VinProduct = vin65WS2.com.vin65.webservicesProduct;       //access the methods directly (instead of using proxy files)


namespace WpfApp1
{
    //DEAN JONES
    //JUN.01, 2017
    //Vin65.xaml.cs
    //view window code for XAML 

    //SUPPORTING FILES 
    //  Vin65.xaml

    //DEFAULT COLORS (see PROJECT, PROPERTIES, SETTINGS tab)
    //#a11232   ColorPrimary
    //#7F3545   ColorSecondary

    //TODO
    //if QUERY DOESN'T WORK (don't allow user to SAVE)
    //
    //HOW TO DEPLOY PROJECT?
    //
    //SETTINGS (NOT UPDATING IN APP.CONFIG)(could be HUGE issued after COMPILING?)(save to external file?)
    //use LINQ (to read/access XML file)
    //
    //ADD (bool) to WriteToXML (XmlController.cs) to verify a FILE IS CREATED...
    //
    //what if SKU textbox is blank?
    //
    //show the successful (after clicking button)(go to xml?)
    //
    //TODO...


    /// <summary>
    /// WINDOW Vin65.xaml
    /// Tabs (Query, XML, Settings)
    /// </summary>
    public partial class MainWindow : Window
    {
        //SETTINGS 
        WpfApp1.Properties.Settings settings = new Settings();


        //CONSTANTS (USERNAME AND PASSWORD)(get from APP.CONFIG settings, so that it's in ONE PLACE)        
        string WS_USERNAME;
        string WS_PASSWORD;

        //VARIABLES      
        ProductController pc;           //create controller (to run query)
        //PS_Response1 response;          //create (Response) object (removed all PS_* due to proxy naming problem)
        VinProduct.Response1 response;
        //PS_Product1 product;            //create (Product) object (removed all PS_* due to proxy naming problem)
        VinProduct.Product1 product;
        List<PS_Product1> products;     //create LIST of (Product) objects


        public MainWindow()
        {
            //SET USERNAME AND PASSWORD (VIN65 API)
            WS_USERNAME = settings.VIN65WS_Username;
            WS_PASSWORD = settings.VIN65WS_Password;

            InitializeComponent();
            //test();     //test if VIN65 API can push to WPF window
            QueryInit();

            //init settings
            SettingsInit();

        }

        //SETTINGS, XML PATH (to save xml files to directory)
        private void btnXmlPath_Click(object sender, RoutedEventArgs e)
        {
            //set current path
            string path = txtXmlPath.Text;

            //CREATE FOLDER object
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = path;         //set default path

            //SELECT FOLDER...
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtXmlPath.Text = folder.SelectedPath;
            }

        }

        //EVENT (BUTTON) XML SAVE (to file)
        private void btnXmlSave_Click(object sender, RoutedEventArgs e)
        {
            //settings object
            //WpfApp1.Properties.Settings settings = new Settings();

            //get XML (string) and PATH (from settings)
            //string xml = XmlController.Serialize(response);
            var xml = XmlController.Serialize(response);
            string path = settings.XmlPath;

            //write to file
            try
            {
                XmlController.WriteXMLToFile(xml, path);

                //messagebox 
                System.Windows.MessageBox.Show("Your XML file has been saved.", "Save to File");
            }
            catch(UnauthorizedAccessException ex1)
            {
                System.Windows.Forms.MessageBox.Show("You have used an incorrect PATH in settings." + "\n" + ex1.Message, "Error");
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An unknown error has occured.", "Error");
            }
            
        }

        //SETTINGS INIT (load setttings from properties to settings tab)
        private void SettingsInit()
        {
            SettingsDefault();
        }

        private void SettingsDefault()
        {
            //connect to settings (project, properties, settings tab)
            //WpfApp1.Properties.Settings settings = new Settings();

            //setttings (per APP.CONFIG)
            txtUsername.Text = settings.VIN65WS_Username;
            txtPassword.Text = settings.VIN65WS_Password;
            txtXmlPath.Text = settings.XmlPath;
        }

        //TOGGLE BUTTON VISIBILITY (Settings tab, Save & Edit buttons)
        private void toggleSaveEditButtons()
        {
            //make save visible (edit button hidden) vice-versa
            if (btnSettingsEdit.IsVisible)
            {
                btnSettingsSave.Visibility = Visibility.Visible;
                btnSettingsCancel.Visibility = Visibility.Visible;

                btnSettingsEdit.Visibility = Visibility.Hidden;

                //edit settings (enable textboxes)
                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
            }
            else if (btnSettingsSave.IsVisible && btnSettingsCancel.IsVisible)
            {              
                btnSettingsEdit.Visibility = Visibility.Visible;

                btnSettingsSave.Visibility = Visibility.Hidden;
                btnSettingsCancel.Visibility = Visibility.Hidden;

                //edit settings (enable textboxes)
                txtUsername.IsEnabled = false;
                txtPassword.IsEnabled = false;
            }
        }

        //BUTTON EVENT (EDIT)(make fields editable)
        private void btnSettingsEdit_Click(object sender, RoutedEventArgs e)
        {
            //make save visible (edit button hidden) vice-versa
            toggleSaveEditButtons();
        }

        //BUTTON EVENT (CANCEL)(cancel changes to the settings)
        private void btnSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            //reset settings to default (in APP.CONFIG)
            SettingsDefault();

            //toggle buttons back
            toggleSaveEditButtons();

            //messagebox 
            System.Windows.MessageBox.Show("Your settings have not been changed.", "Settings");
        }

        //BUTTON EVENT (SAVE)(update settings in (project, properties, settings))
        private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            //make save visible (edit button hidden) vice-versa
            toggleSaveEditButtons();

            //connect to settings (project, properties, settings tab)
            //WpfApp1.Properties.Settings settings = new Settings();

            //PROPERTIES (set to APPLICATION, read-only)
            //PROERTIES (set to USER, read-write)

            //update settings (to be saved in application)
            settings.VIN65WS_Username = txtUsername.Text;
            settings.VIN65WS_Password = txtPassword.Text;
            settings.XmlPath = txtXmlPath.Text;

            //SAVE SETTINGS
            settings.Save();        //*** doesn't update in PROPERTIES TAB? ***

            //messagebox 
            System.Windows.MessageBox.Show("Your settings have been saved.", "Settings");
        }

        //INITIALIZE (QUERY TAB)
        private void QueryInit()
        {
            QueryShowSkuTextbox();
        }

        //EVENT (Query tab)(if SKU is CHECKED, show textbox)
        private void radQueryProductSku_Checked(object sender, RoutedEventArgs e)
        {
            QueryShowSkuTextbox();
        }

        //EVENT (Query tab)(if SKU is UNCHECKED, show textbox)
        private void radQueryProductSku_Unchecked(object sender, RoutedEventArgs e)
        {
            QueryShowSkuTextbox();
        }

        //...
        private void QueryShowSkuTextbox()
        {
            //reset form
            QueryReset();

            if ((bool)radQueryProductSku.IsChecked)
            {
                //SHOW TEXTBOX (to add SKU#)
                txtQuerySku.Visibility = Visibility.Visible;
                //txtQuerySku.Text = "radio is true";
            }
            else
            {
                //HIDE TEXTBOX (to add SKU#)
                txtQuerySku.Visibility = Visibility.Hidden;
                //txtQuerySku.Text = "radio is false";
            }
        }

        private void QueryReset()
        {
            //clear the success display
            txtQuerySuccess.Visibility = Visibility.Hidden;
            //clear xml tab
            txtVin65Xml.Text = "";
        }

        //QUERY ALL PRODUCTS        
        private VinProduct.Response1 QueryAllProducts()         //private PS_Response1 QueryAllProducts()
        {
            bool result;
            double count;

            //variables
            pc = new ProductController(WS_USERNAME, WS_PASSWORD);               //create controller (to run query)
            //response = new PS_Response1();              //create (Response) object
            //product = new PS_Product1();                //create (Product) object for results
            response = new VinProduct.Response1();              //create (Response) object
            product = new VinProduct.Product1();                //create (Product) object for results

            //need to run query 
            //***************************************
            response = pc.PS_SearchAllProducts2();
            //***************************************

            //was result successful?
            result = (bool)response.IsSuccessful;
            count = (double)response.RecordCount;

            if (result && count > 0)      //if true
            {         
                    //create a list of products
                    //products = response.Products;
                    //show results 
                    //txtVin65Xml.Text = XmlController.Serialize(products);     //xml for products
                    txtVin65Xml.Text = XmlController.Serialize(response);       //xml for entire response
            }
            else if (count == 0)
            {
                txtVin65Xml.Text = "There were no results found.";              //RecordCount is zero(0)
            }

            return response;
        }

        //QUERY ONE PRODUCT        
        public VinProduct.Response1 QueryOneProduct(string sku)     //public PS_Response1 QueryOneProduct(string sku)
        {
            bool result;
            double count;

            //variables
            sku = txtQuerySku.Text; //what if it is BLANK or INCORRECT?
            pc = new ProductController(WS_USERNAME, WS_PASSWORD);               //create controller (to run query)

            //response = new PS_Response1();              //create (Response) object
            //product = new PS_Product1();                //create (Product) object for results
            response = new VinProduct.Response1();              //create (Response) object
            product = new VinProduct.Product1();                //create (Product) object for results

            //need to run query 
            //***************************************
            response = pc.PS_SearchProductBySKU2(sku);
            //***************************************

            //was result successful?
            result = (bool)response.IsSuccessful;
            count = (double)response.RecordCount;

            if(result && count > 0)      //if true
            {
                if(count == 1)           //only ONE product (make sure)
                {
                    //create a product
                    //product = response.Products[0];
                    //show results 
                    //txtVin65Xml.Text = XmlController.Serialize(product);      //xml for product
                    txtVin65Xml.Text = XmlController.Serialize(response);       //xml for entire response
                }
            }
            else if (count == 0)
            {
                txtVin65Xml.Text = "There were no results found.";              //RecordCount is zero(0)
            }

            return response;

            //product = pc.PS_SearchProductBySKU(sku);
            //product.

            //product = pc.PS_SearchProductBySKU("739242");

            //need to confirm in was successful



            //need to show results 
            //txtVin65Xml.Text = XmlController.Serialize(pc.PS_SearchProductBySKU(sku));
            //XmlController.Serialize(pc2.PS_SearchAllProducts2()));
        }

        //EVENT (Query tab) BUTTON RUN QUERY (to VIN65 web services)
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            //PS_Response1 response = new PS_Response1();
            VinProduct.Response1 response = new VinProduct.Response1();

            //query one product
            if ((bool)radQueryProductSku.IsChecked)
            {
                //IsQuerySuccessDisplay(QueryOneProduct(txtQuerySku.Text));
                IsQuerySuccessDisplay(QueryOneProduct(txtQuerySku.Text));
            }
            else if ((bool)radQueryProductAll.IsChecked)
            {
                IsQuerySuccessDisplay(QueryAllProducts());
            }
            
        }

        //QUERY SUCCESSFUL     
        private void IsQuerySuccessDisplay(VinProduct.Response1 response)       //private void IsQuerySuccessDisplay(PS_Response1 response)
        {
            bool isSuccessful = (bool)response.IsSuccessful;
            double count = (double)response.RecordCount;

            if (isSuccessful && count > 0)
            {
                //show successful
                txtQuerySuccess.Text = "         Query Successful         ";
                txtQuerySuccess.Visibility = Visibility.Visible;
                txtQuerySuccess.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B21C"));   //green
            }
            else
            {
                //show NOT successful
                txtQuerySuccess.Text = "       Query NOT Successful       ";
                txtQuerySuccess.Visibility = Visibility.Visible;
                txtQuerySuccess.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1D4F"));   //red
            }

        }


        //TEST to query web service
        public void test()
        {
            //PS_Product1 product = new PS_Product1();
            VinProduct.Product1 product = new VinProduct.Product1();

            ProductController pc = new ProductController(WS_USERNAME, WS_PASSWORD);
            product = pc.PS_SearchProductBySKU("739242");

            txtVin65Xml.Text = product.ProductID;
        }

        //RESET XML TEXTBOX
        private void btnXmlReset_Click(object sender, RoutedEventArgs e)
        {
            QueryReset();
        }

        //CLICK (GO TO EPICOR) WINDOW
        private void btnToEpicor_Click(object sender, RoutedEventArgs e)
        {
            //create new (Window object)(Epicor.xaml)
            var main = new Epicor();
            main.Show();
            this.Close();
        }
    }
}
