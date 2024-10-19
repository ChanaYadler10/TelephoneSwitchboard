using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class LogAction
{
    public int LogActionId { get; set; }

    public Guid? Guid { get; set; }

    public string ActionName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
