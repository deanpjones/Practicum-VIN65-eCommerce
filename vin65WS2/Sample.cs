using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vin65WS2.Controller
{
    public class Sample
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Sample()
        {
            this.Id = 1;
            this.FirstName = "firstname";
            this.LastName = "lastname";
        }
    }
}
