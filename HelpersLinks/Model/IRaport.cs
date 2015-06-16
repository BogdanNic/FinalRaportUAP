using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model 
{
   public interface IRaport
    {
        int dbID { get; set; }
        int ID { get; set; }
        string Username { get; set; }
        int Hours { get; set; }
        int Minutes { get; set; }
        int Magazines { get; set; }
        int Brochures { get; set; } 
        int Books{get;set;}
       string Partener { get; set; } 

        int Studies { get; set; }
        int Visits { get; set; }
        DateTime Month { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
