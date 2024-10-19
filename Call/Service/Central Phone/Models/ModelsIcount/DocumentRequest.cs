using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class DocumentRequest
    {
        [JsonProperty("cc")]
        public Cc Cc { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("vatId")]
        public string VatId { get; set; }

        [JsonProperty("doctype")]
        public string Doctype { get; set; }

        [JsonProperty("emailCc")]
        public string EmailCc { get; set; }

        [JsonProperty("emailTo")]
        public string EmailTo { get; set; }

        [JsonProperty("sendEmail")]
        public int SendEmail { get; set; }

        [JsonProperty("taxExempt")]
        public int TaxExempt { get; set; }

        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        [JsonProperty("emailCcMe")]
        public int EmailCcMe { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("emailToClient")]
        public int EmailToClient { get; set; }
    }

}
