using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models
{
    public class GetCallHistory
    {
        public string scustomer { get; set; }
        public string recording { get; set; }
        public string outgroup_name { get; set; }
        public string bill_type { get; set; }
        public string overmax { get; set; }
        public string callerid_external { get; set; }
        public double cost_including_tax { get; set; }
        public string dtype { get; set; }
        public string totaltime { get; set; }
        public string snumber_name { get; set; }
        public string callername { get; set; }
        public string dnumber { get; set; }
        public object spresent { get; set; }
        public string media { get; set; }
        public string cnumber_display { get; set; }
        public string plan { get; set; }
        public string server { get; set; }
        public string dnumber_display { get; set; }
        public double cost { get; set; }
        public string ctype { get; set; }
        public int messages { get; set; }
        public string ingroup_time { get; set; }
        public string owner_cost { get; set; }
        public string uniqueid { get; set; }
        public string archived { get; set; }
        public string taxed { get; set; }
        public string end { get; set; }
        public string outgroup { get; set; }
        public string ingroup { get; set; }
        public string balance { get; set; }
        public string invoice { get; set; }
        public string dcustomer { get; set; }
        public string cnumber { get; set; }
        public string customer_name { get; set; }
        public int start { get; set; }
        public string snumber { get; set; }
        public List<Taxis> taxes { get; set; }
        public string snumber_display { get; set; }
        public string dnumber_name { get; set; }
        public int time { get; set; }
        public string status { get; set; }
        public string stype { get; set; }
        public string channel { get; set; }
        public string cnumber_name { get; set; }
        public string callerid_internal { get; set; }
        public string currency { get; set; }
        public string owner_currency { get; set; }
        public string sname { get; set; }
        public string cost_excluding_tax { get; set; }
        public int messages_used { get; set; }
        public string callid { get; set; }
        public int seconds_used { get; set; }
        public string bridged_callid { get; set; }
        public string owner_cost_including_tax { get; set; }
        public string bill_ref { get; set; }
        public string note { get; set; }
        public string outgroup_time { get; set; }
        public string customer { get; set; }
        public string talktime { get; set; }
        public int peer { get; set; }
        public string owner_cost_excluding_tax { get; set; }

    }
    public class Taxis
    {
        public string currency { get; set; }
        public string cost { get; set; }
        public string tax { get; set; }
    }

}
