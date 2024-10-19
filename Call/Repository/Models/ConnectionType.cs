using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ConnectionType
{
    public int ConnectionTypeId { get; set; }

    public Guid? Guid { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
