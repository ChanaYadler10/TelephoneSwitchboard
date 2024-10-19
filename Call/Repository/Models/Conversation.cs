using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Conversation
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

    public virtual ICollection<Communication> Communications { get; set; } = new List<Communication>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<ConversationStatus> ConversationStatusTbls { get; set; } = new List<ConversationStatus>();
}
