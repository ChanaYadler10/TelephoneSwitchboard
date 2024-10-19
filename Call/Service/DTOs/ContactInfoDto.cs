using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ContactInfoDto
    {
        public int ContactInfoId { get; set; }
        public string InfoType { get; set; }
        public string Info { get; set; }
    }
}
