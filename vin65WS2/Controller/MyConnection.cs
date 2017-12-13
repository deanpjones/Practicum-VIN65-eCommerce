using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vin65WS.Controller
{
    //MYCONNECTION.CS
    //DEAN JONES
    //MAY 30, 2017
    //Allow for connection information in one place (to VIN65 web services)

    public class MyConnection
    {
        //CONSTANTS (for access to web service)(should match VIN65 web service account)
        //string WS_USERNAME = "DeanJonesLIVE";

        //private string WS_USERNAME = "DeanJonesSANDBOX";
        //private string WS_PASSWORD = "willowpark";
        //private string WS_USERNAME;
        //private string WS_PASSWORD;

        //GETTERS AND SETTERS
        public string Ws_Username { get; set; }
        public string Ws_Password { get; set; }

        //public string Ws_Username
        //{
        //    get { return WS_USERNAME; }
        //}

        //public string Ws_Password
        //{
        //    get { return WS_PASSWORD; }
        //}

        //CONSTRUCTOR
        //public MyConnection() { }
        public MyConnection(string user, string pw)
        {
            this.Ws_Username = user;
            this.Ws_Password = pw;
        }

    }
}
