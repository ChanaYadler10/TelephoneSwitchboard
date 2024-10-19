using Service.Central_Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models
{
    public class ApiResponse<T>

    {
       
        public int TotalCount
        {
            get { return Data?.Count ?? 0; }
        }

        // רשימה של אובייקטים מסוג CompletedCall
        public List<T>Data { get; set; }
        public List<ResponseInfo> Responses { get; set; }
    }
}


   
  



