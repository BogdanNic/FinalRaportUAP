using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Links
    {
        public const string Login = "http://bogdan.w.pw/v1/login";
        public const string BaseRest = "http://bogdan.w.pw/v1/raportsNew";
      //  public const string BaseRest = "http://bogdan.w.pw/v1/raports";
        public const string Autorization = "0381bf51b21cf0e83536f9c662a0a371";
        public const string Autorization3 = "144a1a7a0edf10f5fc2d64daeebfdd1a";
        public const string Autorization2= "39026cfdef23c4423245ad5237f8d905";
        public const string Register = "http://bogdan.w.pw/v1/register";
        public const string CheckServer = "http://bogdan.w.pw/v1/raportsNew/preflight";
        public const string GetUpdates = "http://bogdan.w.pw/v1/raportsNew/updateSince";
        public const string Preflight = "http://bogdan.w.pw/v1/raportsNew/preflight"; 
        
        /// <summary>
        /// creates a list of changes 
        /// <paramref name="ListChanges"/> time since last update
        /// example
        /// http://bogdan.w.pw/v1/raportsNew/updateSince/1424000000
        /// </summary>
        public const string ListChanges = "http://bogdan.w.pw/v1/sinceUpdate";
    }
    
}
