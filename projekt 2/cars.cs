using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_2
{
    internal class cars
    {
        public cars (string id, string marka, string segment,string fueltype,decimal priceforaday, string status)
        {
            this.Id = id;
            this.Marka = marka;
            this.segment = segment;
            this.fueltype = fueltype;  
            this.priceforaday = priceforaday;   
            this.status = status;   

        }
        public string Id { get; set; }
        public string Marka { get; set; }
        public string segment { get; set; }
        public string fueltype { get; set; }
        public decimal priceforaday { get; set; }
        public string status { get; set; }
    }
}
