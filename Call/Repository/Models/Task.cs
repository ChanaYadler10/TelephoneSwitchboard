using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public int? StatusTaskTblId { get; set; }

    public string? AssignedTo { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int? ConversationTblId { get; set; }

    public virtual Conversation? ConversationTbl { get; set; }

    public virtual Customer? CustomerTbl { get; set; }

    public virtual StatusTask? StatusTaskTbl { get; set; }
}
