using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ConversationDto
    {

        public int ConversationId { get; set; }
        public Guid? Guid { get; set; }
        public DateTime CallStartTime { get; set; }
        public TimeOnly? CallDuration { get; set; }
        public DateTime? CallEndTime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public List<CommunicationDto> Communications { get; set; } = new List<CommunicationDto>();
    }
}
