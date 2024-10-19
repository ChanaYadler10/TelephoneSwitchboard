using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    using Newtonsoft.Json;

    public class Supplier
    {
        [JsonProperty("supplier_id")]
        public string SupplierId { get; set; }

        [JsonProperty("vat_id")]
        public string VatId { get; set; }

        [JsonProperty("supplier_name")]
        public string SupplierName { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    

    


}
