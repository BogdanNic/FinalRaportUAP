using GalaSoft.MvvmLight;
using Library.Helper_Vm;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using SQLite;
using FinalRaport2.Model;

namespace FinalRaport2.ViewModel
{
    public class AddVM : ViewModelBase
    {
        public AddVM()
        {
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);

        }
        SQLiteAsyncConnection _connection = new SQLiteAsyncConnection("pred.db"); 
        private async void Save()
        { 
           // MessageDialog d = new MessageDialog("save");
            // await d.ShowAsync();

            await _connection.CreateTableAsync<PredRaport>();

            await _connection.InsertAsync(new PredRaport() { Minutes=30, Username="Bog",Studies=2, Hours=2,LastUpdate=DateTime.Now, Command = "ADD" });
    var s= _connection.InsertAsync(new PredRaport() { Minutes=30, Username="Bog",Studies=2, Hours=2,LastUpdate=DateTime.Now, Command = "ADD" });

            var allData = await _connection.Table<PredRaport>().ToListAsync();

            Action<SQLiteAsyncConnection> asd = async (sdd) => { await _connection.InsertAsync(new PredRaport()); };
            //var sd=await _connection.RunInTransactionAsync()
        }  
        
        private async void Cancel()
        {
            MessageDialog d = new MessageDialog("cancel");
            await d.ShowAsync();
        }
        public Command SaveCommand { get; set; }
        public Command CancelCommand { get; set; }
    }
}
