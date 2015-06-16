using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{

    public class MyGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
    {
        public MyGrouping(TKey key,List<TElement> items)
        {
            Items =new List<TElement> (items);
           key=Key;
        }
        public List<TElement> Items { get; set; }
        public TKey Key
        {
            get;
            set;
        }

        public bool IsSourceGrouped = true; 
    }

    public class Group<T> : ObservableCollection<T>, INotifyPropertyChanged
    {
        // private string p;

        public Group(string name, IEnumerable<T> items)
            : base(items)
        {
            this.Title = name;
            this.SUMs = items;
        }
        public Group(string name, IEnumerable<T> items, int hours)
            : base(items)
        {
            this.Title = name;
            this.SumPopulation += hours;

        }
        public Group(string name, IEnumerable<T> items, int minutes, int hours)
            : base(items)
        {
            this.Title = name;
            this.SumPopulation += hours;
            this.SumMinutes += minutes;
        }
        public IEnumerable<T> SUMs { get; set; } 


        

      



        public bool IsSourceGrouped = true; 

        private int _SumPopulation;

        public int SumPopulation
        {
            get { return _SumPopulation; }
            set
            {
                _SumPopulation = value;
                RaisePropertyChanged("SumPopulation");
            }
        }
        private int _SumMinutes;

        public int SumMinutes
        {
            get { return _SumMinutes; }
            set
            {
                _SumMinutes = value;
                RaisePropertyChanged("SumMinutes");
            }
        }

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime dateTime;
        private List<T> list;
        private int p1;
        private int p2;
        private string p;
   
        private int p3;
       


        public string Title
        {
            get;
            set;
        }



    }
}
