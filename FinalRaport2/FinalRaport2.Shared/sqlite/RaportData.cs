using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FinalRaport2.Model;
using System.Threading.Tasks;

namespace FinalRaport2.sqlite
{
   public class RaportData
    {
       private static SQLiteAsyncConnection _conn = new SQLiteAsyncConnection("db.sqlite");

       private static SQLiteConnection _connN = new SQLiteConnection("db.sqlite");
       public async static void DropTable()
       {
         
          var d= await _conn.DropTableAsync<PredRaport>();

          if (d==1)
          {
         
          }
       }
       public async static Task<bool> CreateTable()
       { 
           CreateTablesResult s=await   _conn.CreateTableAsync<PredRaport>();
           if (s.Results.Keys.Count > 0)
           {
               return true;
           }
           else
               return false;
       }

       public async static  Task<List<PredRaport>> SelectAll()
       {
           List<PredRaport> raports = new List<PredRaport>();

           raports = await _conn.Table<PredRaport>().ToListAsync();
           
           return raports;
       }
       public async static Task<string> Delete(PredRaport raport)
       {
        int result=   await _conn.DeleteAsync(raport);
        if (result == 1)
        {
            return "ok";
        }
        else
            return "failed";
       }
       public async static Task<string> Update(PredRaport raport)
       {
           int result = await _conn.UpdateAsync(raport);
           if (result == 1)
           {
               return "ok";
           }
           else
               return "failed";
       }
       public async static Task<string> Insert(PredRaport raport)
       {
           int result = await _conn.InsertAsync(raport);
           if (result == 1)
           {
               return "ok";
           }
           else
               return "failed";
       }
    }
}
