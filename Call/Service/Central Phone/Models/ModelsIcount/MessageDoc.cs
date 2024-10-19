using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class MessageDoc
    {
        [JsonProperty("ts")]
        public double Ts { get; set; }

        [JsonProperty("delta")]
        public double Delta { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public string Data
        {
            get; set;
        }
    }
}
