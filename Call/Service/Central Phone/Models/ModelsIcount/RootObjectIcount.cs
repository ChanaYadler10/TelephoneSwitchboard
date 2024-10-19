using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class RootObject
    {
        public ApiClient ApiClient { get; set; }
        public bool status { get; set; }
        public string reason { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int clients_count { get; set; }
        public Dictionary<string, Client> Clients { get; set; }
        
    }
}
