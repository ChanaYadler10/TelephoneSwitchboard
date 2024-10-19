using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class ApiDoc
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("tz")]
        public int Tz { get; set; }

        [JsonProperty("ts")]
        public double Ts { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("rid")]
        public int Rid { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("messages")]
        public List<MessageDoc> Messages { get; set; }
    }
}
