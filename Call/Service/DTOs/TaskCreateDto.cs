using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class TaskCreateDto
    {
        public int? CustomerTblId { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? StatusTaskTblId { get; set; }
        public string? AssignedTo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ConversationTblId { get; set; }
    }
}
