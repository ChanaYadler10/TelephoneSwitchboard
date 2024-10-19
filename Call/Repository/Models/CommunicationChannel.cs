using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CommunicationChannel
{
    public int ChannelId { get; set; }

    public Guid? Guid { get; set; }

    public int? ChannelDefinitionTblId { get; set; }

    public string ChannelName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CommunicationChannelDefinition? ChannelDefinitionTbl { get; set; }

    public virtual ICollection<Communication> Communications { get; set; } = new List<Communication>();
}
