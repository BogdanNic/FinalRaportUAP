using FinalRaport2.sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using Library.Model;
using Library.Helper_Vm;
namespace FinalRaport2.Model
{
   public class PredRaport:IRaport,INotifyPropertyChanged
    {
      
        
        private int _dbID;
       [JsonIgnore]
       [Column("_id"),PrimaryKey,AutoIncrement]
        public int dbID
        {
            get { return _dbID; }
            set
            {
                if (_dbID != value)
                {
                   
                    _dbID = value;
                    RaisePropertyChanged("dbID");
                }
            }
        }


        private int _ID;
        [JsonProperty("id")]
        [Column("ID")]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                   
                    _ID = value;
                    RaisePropertyChanged("ID");
                }
            }
        }




       private string  _username;
        [JsonProperty("username")]
       [Column("Username")] 
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {

                    _username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        




       private int _Hours;
     [JsonProperty("ore")]
       public int Hours
       {
           get { return _Hours; }
           set
           {
               if (_Hours != value)
               {
                 
                   _Hours = value;
                   RaisePropertyChanged("Hours");
               }
           }
       }


       private int _Minutes;
        [JsonProperty("minute")]
       public int Minutes
       {
           get { return _Minutes; }
           set
           {
               if (_Minutes != value)
               {
                   
                   _Minutes = value;
                   RaisePropertyChanged("Minutes");
               }
           }
       }

       private string _Partener;
      [JsonProperty("partener")]
       public string Partener
       {
           get { return _Partener; }
           set
           {
               if (_Partener != value)
               {

                   _Partener = value;
                   RaisePropertyChanged("Partener");
               }
           }
       }



       private int _Visite;
        [JsonProperty("visite")]
       public int Visits
       {
           get { return _Visite; }  
           set
           {
               if (_Visite != value)
               {
                 
                   _Visite = value;
                   RaisePropertyChanged("Visits");
               }
           }
       }

       private int _Studi;
     [JsonProperty("studi")]
       public int Studies
       {
           get { return _Studi; }
           set
           {
               if (_Studi != value)
               {
                   
                   _Studi = value;
                   RaisePropertyChanged("Studies"); 
               }
           }
       }

       private DateTime _Month;
       [SQLite.Ignore]
       [JsonProperty("month")]
       //[JsonIgnore]
       public DateTime Month
       {
           get { return _Month; }
           set
           {
               if (_Month != value)
               {
                 
                   _Month = value;
                   RaisePropertyChanged("Month");
               }
           }
       }
       [JsonIgnore]
       [SQLite.Column("Month")]
       public string MonthSql
       {
           get { return _Month.ToStringStandard(); }
           set
           {
               DateTime monthToChange = value.toDateTimeFromStandard();
               if(_Month==monthToChange)
               {
                   _Month = monthToChange;
               }
           }
       }



       private int _Carti;
       [SQLite.Column("carti")]
       public int Books
       {
           get { return _Carti; }
           set
           {
               _Carti = value;
               RaisePropertyChanged("Books");
           }
       }
       private int _Reviste;
        [SQLite.Column("reviste")]
       public int Magazines
       {
           get { return _Reviste; }
           set
           {
               _Reviste = value;
               RaisePropertyChanged("Magazines");
           }
       }

       private int _Brosuri;
        [SQLite.Column("brosuri")]
       public int Brochures
       {
           get { return _Brosuri; }
           set
           {
               _Brosuri = value;
               RaisePropertyChanged("Brochures");  
           }
       }

       string _command;
        [JsonProperty(PropertyName="command",NullValueHandling=NullValueHandling.Ignore)]
       
       [Column("Command")]
       public string Command
       {
           get
           {
               return _command;
           }
           set
           {
               if (_command!=value)
               {
                   _command = value;
                   RaisePropertyChanged("Command");
               }
           }
       }
   
       private DateTime _lastUpdate; 
       
       [JsonIgnore]
       [SQLite.Ignore]
       public DateTime LastUpdate
       {
           get { return _lastUpdate; }
           set
           {
               if (_lastUpdate != value)
               {
                   _lastUpdate = value;
                   RaisePropertyChanged("LastUpdate");
               }
           }
       }
       
       [JsonProperty("lastUpdate")]
       [Column("LastUpdate")]
       public long LastUpdateSql { 
           get { return _lastUpdate.ToUnixSeconds(); }
           set
           {
               DateTime dateToChange = value.ToDateTimeFromUnixSeconds();
               if (_lastUpdate != dateToChange)
               {
                   _lastUpdate = dateToChange;
                   RaisePropertyChanged("LastUpdateTime");
               }
           }
          }

       

       #region notify
        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;

     
       #endregion
     }

  
 

    }
