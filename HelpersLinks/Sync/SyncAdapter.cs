using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Sync
{
   public class SyncAdapter
    {
       public static void OnPerform(User user)
       {

       }
       private static async Task<bool> respondPush(User user)
       {
           return true;
       }
       private void manualRequest(User user)
       {

       }
       
    }
}
