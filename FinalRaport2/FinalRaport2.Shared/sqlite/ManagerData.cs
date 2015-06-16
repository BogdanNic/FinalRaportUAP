using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using System.Linq;
using FinalRaport2.Model;
using System.Collections.ObjectModel;
using Library.Web;
using System.ComponentModel;
namespace FinalRaport2.sqlite
{
   public class ManagerData:INotifyPropertyChanged
    {
       private async void LoadData2() 
       {
           PivotCollection.Clear();
           List<PredRaport> raports = null;
           try
           {
               raports = await RestBasedDB<PredRaport>.SelectAll();
           }
           catch (Exception e)
           {
               MessageDialog d = new MessageDialog(e.Message);
               throw;
           }

           if (raports.Count == 0) return;
           var anualRap = raports.GroupBy<PredRaport, int>(c => c.Month.Year);
           foreach (var anual in anualRap)
           {
               RaportGroupModel an = new RaportGroupModel();
               an.Name = anual.Key.ToString();
               an.Collection = new ObservableCollection<PredRaport>(anual.ToList());
               an.Refresh();
               PivotCollection.Add(an);
           }
       }
       private ObservableCollection<RaportGroupModel> _PivotCollection;
       public ObservableCollection<RaportGroupModel> PivotCollection
       {
           get { return _PivotCollection; }
           set
           {
               _PivotCollection = value;
               RaisePropertyChanged("PivotCollection");
           }
       }
       private void RaisePropertyChanged(string p)
       {
           if (PropertyChanged!=null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(p));
           }
       }

       public event PropertyChangedEventHandler PropertyChanged;
    }
}
