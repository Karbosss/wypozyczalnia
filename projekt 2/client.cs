using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_2
{
        public class client
        {
       
       
            public client(string id, string name,int year, int month , int day )
            {
                this.Id = id;
                this.Name = name;
                this.Year = year;   
                this.Month = month; 
                this.Day = day;
            }
            public string Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }
}
