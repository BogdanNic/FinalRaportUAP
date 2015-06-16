using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helper_Vm
{
    public static class ConvertToUnix
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixSeconds(this DateTime dateTime)
        {
            return (long)(dateTime - UnixEpoch).TotalSeconds;
        }
        public static DateTime ToDateTimeFromUnixSeconds(this long seconds)
        {
            return UnixEpoch.AddSeconds(seconds);
        }
        public static string ToStringUnix(this DateTime dateTime)
        {
            return ((long)(dateTime - UnixEpoch).TotalSeconds).ToString();
        }
        public static string ToStringStandard(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }
        public static DateTime toDateTimeFromStandard(this string dates)
        {
            //DateTime.Parse(dates,new test(),System.Globalization.DateTimeStyles.AdjustToUniversal );
            return DateTime.Parse(dates);
        }
        class BogFormatProvider : IFormatProvider
        {


            object IFormatProvider.GetFormat(Type formatType)
            {
                throw new NotImplementedException();
            }
        }

    }
}
