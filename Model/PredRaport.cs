using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
namespace Model
{
        [Table]
        public class PredRaport : INotifyPropertyChanged, IBog, INotifyPropertyChanging, IRaport
        {
            //public int ID { get; set; }
            // public string Name { get; set; }
            // public int Hours { get; set; }
            //  public int Minutes { get; set; }
            // public string Partener { get; set; }
            // public int Visite { get; set; }
            //  public int Studi { get; set; }
            public string Username { get; set; }
            //public DateTime Month { get; set; }



            private int _dbID;
            [Column(Name = "_ID", DbType = "INT NOT NULL Identity", CanBeNull = false, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
            public int dbID
            {
                get { return _dbID; }
                set
                {
                    if (_dbID != value)
                    {
                        RaisePropertyChanging("dbID");
                        _dbID = value;
                        RaisePropertyChanged("dbID");
                    }
                }
            }


            private int _ID;

            [Column(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
            public int ID
            {
                get { return _ID; }
                set
                {
                    if (_ID != value)
                    {
                        RaisePropertyChanging("ID");
                        _ID = value;
                        RaisePropertyChanged("ID");
                    }
                }
            }



            private string _Name;


            [Column(Name = "Name")]
            public string Name
            {
                get { return _Name; }
                set
                {
                    if (_Name != value)
                    {
                        RaisePropertyChanging("Name");
                        _Name = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }

            [Column(IsVersion = true)]
            private Binary _version;


            private int _Hours;
            [Column]
            public int Hours
            {
                get { return _Hours; }
                set
                {
                    if (_Hours != value)
                    {
                        RaisePropertyChanging("Hours");
                        _Hours = value;
                        RaisePropertyChanged("Hours");
                    }
                }
            }


            private int _Minutes;
            [Column]
            public int Minutes
            {
                get { return _Minutes; }
                set
                {
                    if (_Minutes != value)
                    {
                        RaisePropertyChanging("Minutes");
                        _Minutes = value;
                        RaisePropertyChanged("Minutes");
                    }
                }
            }

            private string _Partener;
            [Column(CanBeNull = true)]
            public string Partener
            {
                get { return _Partener; }
                set
                {
                    if (_Partener != value)
                    {
                        RaisePropertyChanging("Partener");
                        _Partener = value;
                        RaisePropertyChanged("Partener");
                    }
                }
            }



            private int _Visite;
            [Column]
            public int Visite
            {
                get { return _Visite; }
                set
                {
                    if (_Visite != value)
                    {
                        RaisePropertyChanging("Visite");
                        _Visite = value;
                        RaisePropertyChanged("Visite");
                    }
                }
            }

            private int _Studi;
            [Column]
            public int Studi
            {
                get { return _Studi; }
                set
                {
                    if (_Studi != value)
                    {
                        RaisePropertyChanging("Studi");
                        _Studi = value;
                        RaisePropertyChanged("Studi");
                    }
                }
            }

            private DateTime _Month;
            [Column(CanBeNull = true)]
            public DateTime Month
            {
                get { return _Month; }
                set
                {
                    if (_Month != value)
                    {
                        RaisePropertyChanging("Month");
                        _Month = value;
                        RaisePropertyChanged("Month");
                    }
                }
            }
            private int _Carti;
            [Column]
            public int Carti
            {
                get { return _Carti; }
                set
                {
                    _Carti = value;
                    RaisePropertyChanged("Carti");
                }
            }
            private int _Reviste;
            [Column]
            public int Reviste
            {
                get { return _Reviste; }
                set
                {
                    _Reviste = value;
                    RaisePropertyChanged("Reviste");
                }
            }

            private int _Brosuri;
            [Column]
            public int Brosuri
            {
                get { return _Brosuri; }
                set
                {
                    _Brosuri = value;
                    RaisePropertyChanged("Brosuri");
                }
            }

            private bool _isSync;
            [Column]
            public bool isSync
            {
                get { return _isSync; }
                set
                {
                    if (_isSync != value)
                    {
                        RaisePropertyChanging("isSync");
                        _isSync = value;
                        RaisePropertyChanged("isSync");
                    }
                }
            }


            #region notify
            private void RaisePropertyChanged(string p)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
                }
            }

            private void RaisePropertyChanging(string p)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(p));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            public event PropertyChangingEventHandler PropertyChanging;
            #endregion
        }

        public class RaportContext : DataContext
        {
            public static readonly string CONNECTION = "Data Source=isostore:/raports.sdf";
            public RaportContext(string connection)
                : base(connection)
            {

            }
            public Table<PredRaport> RaportsDB;

        }
        public class Raport
        {
            public int id;
            public int ore;
            public int minute;
            public string username;

            public string partener;
            public int carti;
            public DateTime month;
            public int visite;
            public int reviste;
            public int brosuri;

        }
        public class JsonResponse
        {
            public bool error;
            public string api_key { get; set; }
            public Raport raport;
            public string message;
            public int raport_id;
        }


    }

}
