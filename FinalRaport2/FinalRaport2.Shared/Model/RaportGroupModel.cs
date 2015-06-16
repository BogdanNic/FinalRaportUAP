using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Library.Model;
namespace FinalRaport2.Model
{
    public class RaportGroupModel : INotifyPropertyChanged
    {
        Func<PredRaport, string> Criteria;
     
        public RaportGroupModel()
        {
            ListGroup = new ObservableCollection<Group<PredRaport>>();
            Collection = new ObservableCollection<PredRaport>();
        }
        public bool IsSourceGrouped = true; 
        public void Add(PredRaport raport)
        {
            Collection.Add(raport);

            Refresh();
            //RestBasedBD.Add(raport);
        }
        public void Remove(PredRaport raport)
        {
            Collection.Remove(raport);

            Refresh();
            //RestBasedBD.Remove(raport);
        }
        public void Update(PredRaport raport)
        {

            Refresh();
           // RestBasedBD.Update(raport);
        }

        public async void Refresh()
        {
            var d = await Task.Run(() =>
            {
                return from rapY in Collection
                       orderby rapY.Month.Month ascending
                       group rapY by rapY.Month.ToString("MMMM") into l
                       select new Group<PredRaport>(l.Key.ToString(), l.ToList(), AddHours(l.Sum(c => c.Minutes)), l.Sum(c => c.Hours) + hours);
            });
           // var ds = d.ToList();
            ListGroup = new ObservableCollection<Group<PredRaport>>(d);

        }
        
        

        private ObservableCollection<Group<PredRaport>> _ListGroup;

        public ObservableCollection<Group<PredRaport>> ListGroup
        {
            get { return _ListGroup; }
            set
            {
                _ListGroup = value;
                RaisePropertyChanged("ListGroup");
            }
        }
        
        private ObservableCollection<PredRaport> _Collection;

        public ObservableCollection<PredRaport> Collection
        {
            get { return _Collection; }
            set
            {
                _Collection = value;
                RaisePropertyChanged("Collection");
            }
        }



        #region inotify

        int hours = 0;

        private int AddHours(int minutes)
        {
            hours = 0;
            while (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            return minutes;
        }

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        #region unusesed
private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public void CreateGroup(IEnumerable<PredRaport> list)
        {
            var anual = from rapY in list
                        orderby rapY.Month.Month ascending
                        group rapY by rapY.Month.ToString("MMMM") into l
                        select new Group<PredRaport>(l.Key.ToString(), l.ToList(), AddHours(l.Sum(c => c.Minutes)), l.Sum(c => c.Hours) + hours);
            ListGroup = new ObservableCollection<Group<PredRaport>>(anual);
        }
        #endregion

    }
}
