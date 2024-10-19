using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class ApiResponse
    {
        [JsonProperty("api")]
        public SupplierResponse Api { get; set; }
    }
}
