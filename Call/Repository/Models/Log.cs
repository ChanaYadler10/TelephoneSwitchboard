using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Log
{
    public int LogId { get; set; }

    public Guid? Guid { get; set; }

    public string? TableName { get; set; }

    public int? RecordId { get; set; }

    public int? LogActionTblId { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string? UserName { get; set; }

    public string? Machine { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual LogAction? LogActionTbl { get; set; }
}
