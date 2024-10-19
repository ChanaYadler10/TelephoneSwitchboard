using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models
{
    public class Ivr
    {
        public string language { get; set; }
        public string allow_number { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string password { get; set; }
        public string dialplan { get; set; }
        public string customer { get; set; }
        public string timeout { get; set; }
        public string id { get; set; }
        public string dtype { get; set; }
        public string dnumber { get; set; }
        public string ivr { get; set; }
        
    }
}
