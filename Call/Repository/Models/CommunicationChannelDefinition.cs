using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CommunicationChannelDefinition
{
    public int ChannelDefinitionId { get; set; }

    public Guid? Guid { get; set; }

    public string ChannelName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<CommunicationChannel> CommunicationChannels { get; set; } = new List<CommunicationChannel>();
}
