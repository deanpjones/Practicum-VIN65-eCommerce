using EpicorEagle.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPWS_Middleware.Objects;

namespace WPWS_Middleware.Testing
{
    public static class TestConvert
    {

        //TEST (MySQL --> Epicor object --> Vin65 object --> ???push to VIN65???)
        public static InventoryVIN65 TestConvertEpicorToVin65()
        {
            //create new object (Epicor)
            InventoryEpicor epicorObj = new InventoryEpicor();
            //create a new object (Vin65)
            InventoryVIN65 vin65Obj = new InventoryVIN65();

            //get data for Epicor object     
            epicorObj.ConvertDataTableToObject("18");
            //convert from Epicor --> Vin65
            vin65Obj = epicorObj.InventoryEpicorToVIN65();

            //print to console
            System.Console.WriteLine("Epicor Object: \n" + epicorObj.ToString());
            System.Console.WriteLine("---");
            System.Console.WriteLine("Vin65 Object: \n" + vin65Obj.ToString());

            return vin65Obj;

        }
        
    }
}
