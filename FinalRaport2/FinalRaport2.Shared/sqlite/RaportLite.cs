using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalRaport2.sqlite
{
   
   public class RaportLite
    {
       [PrimaryKey,AutoIncrement,NotNull]
        public int _id { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public long LastUpdate { get; set; }
        public string Month { get; set; }
        public int Magazines { get; set; }
        public int Books { get; set; }
        public int Brochures { get; set; } 
        public int Studi { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Studies { get; set; }
        public string Command { get; set; }  
  
       //public Studiu Studiul { get; set; }  

    }
    public class Studiu
	{
         [PrimaryKey,AutoIncrement,NotNull]
        public int _id { get; set; }
        public string   Name { get; set; }
	}
}
