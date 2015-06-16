using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Serialization
{
  public  class Serialize<T>
    {     
        public static IEnumerable<T> ListDesSerializer(string jsonString)
        {
            //toate merg dar trb sa verifi sa fi totul in regula la db sa nu apara null sau 0000-00-00 00:00;00
            IsoDateTimeConverter conv = new IsoDateTimeConverter();
            conv.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            //System.Globalization.CultureInfo theCultureInfo = new System.Globalization.CultureInfo("fr-CA");
           // conv.Culture = theCultureInfo;
            DefaultValueHandling sd = new DefaultValueHandling();
            IEnumerable<T> t = null;
            try
            {
             t = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString, conv);
            }
            catch (Exception e)
            {

                throw;
            }
           
            return t;
        }
        public static string ListSerializer(IEnumerable<T> list)
        {
            IsoDateTimeConverter conv = new IsoDateTimeConverter();
            conv.DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
            string jsonString = JsonConvert.SerializeObject(list, conv);
            return jsonString;
        }
        public static T DeserializeObj(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }
        static IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("fr-CA");
        
        
        public static DateTime DateConvert(string date)
        {

            try
            {
                return DateTime.ParseExact(date, "yyyy-MM-dd hh:mm:ss", theCultureInfo);

            }
            catch (Exception e)
            {
                var e2 = e.Message;
            }

            return DateTime.Now; ;
        }
    }
}
