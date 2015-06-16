using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Helper_Vm;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using FinalRaport2.Model;
using Library.Model;
using System.Linq;
using Windows.UI.Xaml.Data;
using Library.Web;
using Library.Serialization;
using System.Threading.Tasks;
namespace FinalRaport2.ViewModel
{
   public class HomeVM:ViewModelBase
    {

       public HomeVM()
       {
           TestCommand = new Command(Test);
           PivotCollection = new ObservableCollection<RaportGroupModel>();
           LoadData();
           CurrentMonth = PivotCollection[0];

           var date = DateTime.Now;
           var month = date.Month;
           var year = date.Year;
           CurrentRaport = new PredRaport(); 

       }      
       
       public Command SaveCommand { get; set; }
       public Command TestCommand { get; set; }
       public Command Register { get; set; }

       private RaportGroupModel _currentMonth;
       public RaportGroupModel CurrentMonth
       {
           get { return _currentMonth; }
           set {
               _currentMonth = value;
               RaisePropertyChanged("CurrentMonth");
           }
       }


       private async void Test()
       {
          // MessageDialog dialog = new MessageDialog("sal"+pivotIndex);
          // dialog.ShowAsync();
          // PivotCollection[pivotIndex].Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 2, Hours = 10 });
           //LoadData2();
           PredRaport raport = new PredRaport(); 
           raport.LastUpdate = DateTime.Now;
           raport.Month = DateTime.Now;

           raport.Hours = 1; 
           raport.Minutes = 15;
           raport.Magazines = 1;
           raport.Brochures = 2;
           raport.Books = 3;
           raport.Visits = 4;          
           raport.Studies = 5;
           raport.Username = "b1";
           raport.Partener = "Geo";
        
           
           User user = new User() { Username = "b1", Password = "123456" };
       // var ss= await RestBasedDB<PredRaport>.Login(user);
        // LoadData2();
         //  PredRaport pred=new PredRaport();
          // pred.ID=833;
         //  pred.LastUpdate=DateTime.Now;
          //var s2 = await RestBasedDB<PredRaport>.Insert(raport);


              raport.ID = 863;
              raport.LastUpdate = DateTime.Now;
              raport.Minutes = 30;

              PivotCollection[0].Add(raport);
            
             // var ss4 = await RestBasedDB<PredRaport>.CheckServer();
          
           //var dd2=  await RestBasedDB<PredRaport>.Delete(pred);
           
       }
       private PredRaport _currentRaport;
       public PredRaport CurrentRaport
       { 
           get
           {
               return _currentRaport;
           }
           set
           {
               _currentRaport = value;
               RaisePropertyChanged("CurrentRaport");
           }
       }

       private int _pivotIndex;
       public int pivotIndex
       {
           get 
           {
               return _pivotIndex;
           }
           set
           {
               _pivotIndex=value;
               RaisePropertyChanged("pivotIndex");
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



       #region LoadData
       private async void LoadData2()
       {
           PivotCollection.Clear();
           List<PredRaport> raports=null;
           try
           {
            raports = await RestBasedDB<PredRaport>.SelectAll();
           }
           catch (Exception e)
           {
               MessageDialog d = new MessageDialog(e.Message);
               throw;
           }
           
           if (raports.Count ==0) return;
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


       private void LoadData()
       {
           List<PredRaport> list = new List<PredRaport>();
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 1, Hours = 5 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 1, Hours = 5 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 1, Hours = 5 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddMonths(1), Command = "test", Books = 1, Hours = 5 });

           RaportGroupModel anualRaport = new RaportGroupModel();
           anualRaport.Name = "2014";
           anualRaport.Collection = new ObservableCollection<PredRaport>(list);
           anualRaport.Refresh();
           PivotCollection.Add(anualRaport);
           list.Clear();
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 2, Hours = 1 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 2, Hours = 1 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now, Command = "test", Books = 2, Hours = 1 });
           list.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddMonths(1), Command = "test", Books = 2, Hours = 1 });
           RaportGroupModel anualRaport2 = new RaportGroupModel();
           anualRaport2.Name = "2015";
           anualRaport2.Collection = new ObservableCollection<PredRaport>(list);
           anualRaport2.Refresh();
           PivotCollection.Add(anualRaport2);
       }

#endregion
      
       








    }
}
