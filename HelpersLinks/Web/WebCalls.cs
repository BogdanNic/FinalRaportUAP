
using Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Library.Helper_Vm;
namespace Library.Web 
{
    public class WebCalls
    {
        public static string ErrorMess = "{'error':true,'message':'net'}";


        private static void SettingClient(HttpClient client,String auth)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "WindowsPhone 8");
#if WINDOWS_APP
            client.DefaultRequestHeaders.Add("User-Agent", "Windows");
#endif
#if WINDOWS_PHONE_APP
           client.DefaultRequestHeaders.Add("User-Agent", "Windows Phone");
#endif
            client.DefaultRequestHeaders.Add("Authorization", auth);
            client.DefaultRequestHeaders.Add("content", "application/json");
        }

        public static async Task<string> Get(string link, string auth,int updateSince)
        {          
            string finalLink="";
            switch (link)
            {
                case Links.BaseRest: finalLink = link; break;
                case Links.GetUpdates: finalLink = link + "/" + updateSince.ToString(); break;
                case Links.Preflight: finalLink = link; break;
                default:
                    break;
            } 
            var client = new HttpClient();
            SettingClient(client,auth);
            try
            {
                var response = await client.GetAsync(new Uri(finalLink));
                String s= await response.Content.ReadAsStringAsync();
                return s;
            }
            catch (Exception ex)
            {

                throw;
            }
            return ErrorMess;

        }
        public static async Task<string> Post(string link,string auth,string username,string password,string email,IRaport raport,Operation operation,string name)
        {
            var client = new HttpClient();
            SettingClient(client, auth);

            HttpFormUrlEncodedContent content = null;
            switch (operation)
            {
                case Operation.Register: content = RegisterParam(email, username, name, password); break;
                case Operation.Login: content = AuthParam(username, password); break;
                case Operation.Insert: content = RaportParam(raport); break;    
            }
            try
            {
                var response = await client.PostAsync(new Uri(link), content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }     
        public static async Task<string> Put(string link, string auth, Operation op, IRaport raport)
        {
            HttpFormUrlEncodedContent content = null;
            content = RaportParam(raport);
            string finalLink = link + "/" + raport.ID.ToString()+"?lastUpdate="+raport.LastUpdate.ToUnixSeconds().ToString();
            
            HttpClient client = new HttpClient();
            SettingClient(client, auth);
            try
            {
                var ss = await client.PutAsync(new Uri(finalLink, UriKind.Absolute), content);
                return await ss.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<string> Delete(string link, string auth, Operation op,int raportID,string lastUpdate)
        {
            string finalString = link + "/" + raportID.ToString() + "?" + "lastUpdate=" + lastUpdate;
            HttpClient client = new HttpClient();
            SettingClient(client, auth);
            try
            {
                var j= await client.DeleteAsync(new Uri(finalString));

                return await j.Content.ReadAsStringAsync();
            }
            catch (Exception e )
            {
                throw;
            }
            
        }


        private static HttpFormUrlEncodedContent RaportParam(IRaport raport) 
        {
            DateTime m1 = raport.Month;

            string m = raport.Month.ToString("yyyy-MM-dd HH:mm:ss");
            var content = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("ore", raport.Hours.ToString()),
                new KeyValuePair<string,string>("minute", raport.Minutes.ToString()),
                new KeyValuePair<string,string>("month",raport.Month.ToString("yyyy-MM-dd HH:mm:ss")),
                new KeyValuePair<string,string>("partener", raport.Partener),
                new KeyValuePair<string,string>("reviste", raport.Magazines.ToString()),
                new KeyValuePair<string,string>("brosuri", raport.Brochures.ToString()),
                new KeyValuePair<string,string>("carti", raport.Books.ToString()),
                new KeyValuePair<string,string>("studi", raport.Studies.ToString()),
                new KeyValuePair<string,string>("visite", raport.Visits.ToString()),
                new KeyValuePair<string,string>("lastUpdate",raport.LastUpdate.ToUnixSeconds().ToString())
            });
            return content;

        }
        private static HttpFormUrlEncodedContent RegisterParam(string email, string username,string name, string password)
        {
            var content = new HttpFormUrlEncodedContent(new[] { 
               new KeyValuePair<string,string>("email",email),
               new KeyValuePair<string,string>("password",password),
               new KeyValuePair<string,string>("name",name),
               new KeyValuePair<string,string>("username",username),
            });
            return content;
        }
        private static HttpFormUrlEncodedContent AuthParam(string username, string password)
        {
            var content = new HttpFormUrlEncodedContent(new[] { 
               new KeyValuePair<string,string>("password",password),
               new KeyValuePair<string,string>("username",username),
            });
            return content;
        }


       
    }
}
