using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class CreateClient
    {
        public string customClientId { get; set; }
        public int vatId { get; set; }
        public string email { get; set; }
        public string clientName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string fax { get; set; }
        public string busCountry { get; set; }
        public string busState { get; set; }
        public string busCity { get; set; }
        public int busZip { get; set; }
        public string busStreet { get; set; }
        public string busNo { get; set; }
        public string homeCountry { get; set; }
        public string homeState { get; set; }
        public string homeCity { get; set; }
        public int homeZip { get; set; }
        public string homeStreet { get; set; }
        public string homeNo { get; set; }
        public int bank { get; set; }
        public int branch { get; set; }
        public int account { get; set; }
        public int faccount { get; set; }
        public string notes { get; set; }
        public bool digsig { get; set; }
        public string customInfo { get; set; }
    }
}
