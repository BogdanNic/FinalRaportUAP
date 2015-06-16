using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Library.Serialization
{
    public class JsonResponse
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("api_key")]
        public string Authorization { get; set; }
        
        [JsonProperty("raport_id")]
        public int RaportID { get; set; }
    }
}
