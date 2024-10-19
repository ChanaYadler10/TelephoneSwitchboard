using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models
{
    public class RetrievingRecording
    {
        public string scustomer { get; set; }
        public string stype { get; set; }
        public string status { get; set; }
        public string callerid_internal { get; set; }
        public string size { get; set; }
        public string dtype { get; set; }
        public string totaltime { get; set; }
        public string dnumber { get; set; }
        public int spresent { get; set; }
        public string server { get; set; }
        public string callid { get; set; }
        public string ctype { get; set; }
        public string name { get; set; }
        public string uniqueid { get; set; }
        public string data { get; set; }
        public string path { get; set; }
        public string stale { get; set; }
        public string end { get; set; }
        public string dcustomer { get; set; }
        public string recordid { get; set; }
        public string cnumber { get; set; }
        public string recordgroup { get; set; }
        public string talktime { get; set; }
        public string mimetype { get; set; }
        public string snumber { get; set; }
        public string start { get; set; }
        public string complete { get; set; }
        public string expires { get; set; }
        public string snumber_display { get; set; }
        public string dnumber_name { get; set; }
        public string cnumber_name { get; set; }
        public string snumber_name { get; set; }
        public string cnumber_display { get; set; }
        public string dnumber_display { get; set; }
        public byte[] AudioData { get; set; } // או Data, תלוי בשם השדה שמחזיק את נתוני האודיו



    }
}
