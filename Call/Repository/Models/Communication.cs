using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Communication
{
    public int CommunicationId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public int? ChannelTblId { get; set; }

    public int? CorrespondenceTypeTblId { get; set; }

    public int? ParentCommunicationTblId { get; set; }

    public string? Subject { get; set; }

    public string? Content { get; set; }

    public string? Ipaddress { get; set; }

    public string? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int? ConversationTblId { get; set; }

    public virtual CommunicationChannel? ChannelTbl { get; set; }

    public virtual ICollection<CommunicationRepresentative> CommunicationRepresentatives { get; set; } = new List<CommunicationRepresentative>();

    public virtual Conversation? ConversationTbl { get; set; }

    public virtual CorrespondenceType? CorrespondenceTypeTbl { get; set; }

    public virtual Customer? CustomerTbl { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Communication> InverseParentCommunicationTbl { get; set; } = new List<Communication>();

    public virtual Communication? ParentCommunicationTbl { get; set; }
}
