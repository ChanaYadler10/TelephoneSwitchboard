using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class Cc
    {
        [JsonProperty("sum")]
        public int Sum { get; set; }

        [JsonProperty("expYear")]
        public int ExpYear { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("expMonth")]
        public int ExpMonth { get; set; }

        [JsonProperty("holderId")]
        public string HolderId { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("holderName")]
        public string HolderName { get; set; }

        [JsonProperty("confirmationCode")]
        public string ConfirmationCode { get; set; }
    }
}
