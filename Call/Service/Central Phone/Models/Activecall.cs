using Service.Central_Phone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models
{
    public class Activecall
    {
        public int answered { get; set; }
        public int billing_peer { get; set; }
        public string callerid_external { get; set; }
        public string callerid_internal { get; set; }
        public string callername_external { get; set; }
        public string callername_internal { get; set; }
        public string callid { get; set; }
        public string channel { get; set; }
        public string cnumber { get; set; }
        public string ctype { get; set; }
        public int dcustomer { get; set; }
        public string dnumber { get; set; }
        public string dtype { get; set; }
        public int ingroup { get; set; }
        public int machine { get; set; }
        public int outgroup { get; set; }
        public int overmax { get; set; }
        public int peer { get; set; }
        public string recording { get; set; }
        public int scustomer { get; set; }
        public string sip_callid { get; set; }
        public string snumber { get; set; }
        public int spresent { get; set; }
        public int start { get; set; }
        public string status { get; set; }
        public string stype { get; set; }
        public string uniqueid { get; set; }
    }
}
