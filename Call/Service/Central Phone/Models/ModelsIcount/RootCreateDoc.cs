using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class RootCreateDoc
    {
        public Cc cc { get; set; }
        public string lang { get; set; }
        public string email { get; set; }
        public List<Item> items { get; set; }
        public string vatId { get; set; }
        public string doctype { get; set; }
        public string emailCc { get; set; }
        public string emailTo { get; set; }
        public int sendEmail { get; set; }
        public int taxExempt { get; set; }
        public string clientName { get; set; }
        public int emailCcMe { get; set; }
        public string currencyCode { get; set; }
        public int emailToClient { get; set; }
    }
}
