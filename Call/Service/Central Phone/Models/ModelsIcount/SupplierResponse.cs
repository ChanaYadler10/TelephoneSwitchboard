using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class SupplierResponse
    {
        [JsonProperty("suppliers_count")]
        public int SuppliersCount { get; set; }

        [JsonProperty("suppliers")]
        public Dictionary<string, Supplier> Suppliers { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
