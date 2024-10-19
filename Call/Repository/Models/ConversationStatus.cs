using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ConversationStatus
{
    public int ConversationStatusId { get; set; }

    public Guid? Guid { get; set; }

    public string StatusName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public bool? IsConversationOpen { get; set; }

    public virtual ICollection<Conversation> ConversationTbls { get; set; } = new List<Conversation>();
}
