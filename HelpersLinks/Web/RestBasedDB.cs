
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Library.Model;
using Library.Web;
using Library.Serialization;
using Library.Helper_Vm;
using Library.Serialization;
namespace Library.Web   
{
  public  class RestBasedDB<T> where T:IRaport   
    {
       static string error = "{error:true,message:net}";
       public enum Result
       {
           OK,
           ERROR
       }

       #region Basic commands Login

       private static string Authorization = "39026cfdef23c4423245ad5237f8d905";
        
         public static async Task<string>  Login(User user)
        {
            JsonResponse json = null;
            try
            {
                string responseString = await WebCalls.Post(Links.Login, "s", user.Username, user.Password, "", null, Operation.Login, "");

                json = Serialize<JsonResponse>.DeserializeObj(responseString);
            }
            catch (JsonException jsonEx)
            {

                throw new Exception("json decoding error", jsonEx);
            }

            if (json.Error)
            {
                throw new Exception(json.Message);
            }
            else
            {
                Authorization = json.Authorization;
                return Result.OK.ToString();
            }

        }
        
        public static async Task<string>  Register(User user)
        {
            JsonResponse json = null;
            try
            { 
                string responseString= await WebCalls.Post(Links.Register, "s", user.Username, user.Password, user.Email, null, Operation.Register, user.Name);
           
                json = Serialize<JsonResponse>.DeserializeObj(responseString);
            }
            catch (JsonException jsonEx)
            {
                
                throw new  Exception("json decoding error",jsonEx);
            }
           
            if (json.Error)
            {
                throw new Exception(json.Message);
            }
            else
            {
                return Result.OK.ToString();
            }
        }
        
        public static async Task<List<T>> SelectAll()
        {
              List<T> raports =new List<T>();
              try
              {
                  string message = await WebCalls.Get(Links.BaseRest,Authorization, 0);

                  if (message!=String.Empty)
                  {
                    raports.AddRange( Serialize<T>.ListDesSerializer(message));
                  }

              }
              catch (Exception )
              {
                  
                  throw;
              }
              

            
            return raports;
        }
        public static async Task<string> Insert(T raport)
        {
            string responseString=await WebCalls.Post(Links.BaseRest, Authorization, "", "", "", raport, Operation.Insert, "");
            JsonResponse json = null;
            if (responseString == "") return "error";
            try
            {
                json = Serialize<JsonResponse>.DeserializeObj(responseString);
            }
            catch (Exception e)
            {

                throw new JsonException(e.Message);
            }
            if (json.Error)
            {
                throw new Exception(json.Message);
            }
            else
            {
                return Result.OK.ToString();
            }

         
        }
        public static async Task<string> Delete(T raport)
        {
            //String link = Links.BaseRest +"/"+ raport.ID + "?" + "lastUpdate=" + raport.LastUpdate.ToUnixSeconds().ToString();

            string responseString = await WebCalls.Delete(Links.BaseRest, Authorization, Operation.Delete, raport.ID, raport.LastUpdate.ToUnixSeconds().ToString());
            JsonResponse json = null;
            try
            {
               json = Serialize<JsonResponse>.DeserializeObj(responseString);
            }
            catch (Exception e)
            {              
                throw new JsonException(e.Message);
            }
            if (json.Error)
            {

                throw new Exception(json.Message);
            }
            else
            {
                return Result.OK.ToString();
            }
        }
        public static async Task<string> Update(T raport)
        {
            var responseString = await WebCalls.Put(Links.BaseRest, Authorization, Operation.Update, raport);

            JsonResponse json = null;
            try
            {
                json = Serialize<JsonResponse>.DeserializeObj(responseString);
            }
            catch (Exception e)
            {

                throw new JsonException(e.Message);
            }
            if (json.Error)
            {
                throw new Exception(json.Message);
            }
            else
            {
                return Result.OK.ToString();
            }
        }
        public static async Task<string> CheckServer()
        {
            string result=await WebCalls.Get(Links.Preflight, "s", 0);
            if (result==""||result==null)
            {
                return Result.ERROR.ToString();
            }
            try
            {
                JsonResponse json = Serialize<JsonResponse>.DeserializeObj(result);
            }
            catch (Exception e)
            {
                
                throw;
            }
            return Result.OK.ToString();
        }
        public static async Task<string> Sync()
        {
            return error;
        }

       #endregion


    }
}
