using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class PurchaseDto
    {

        public int PurchaseId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Amount { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
