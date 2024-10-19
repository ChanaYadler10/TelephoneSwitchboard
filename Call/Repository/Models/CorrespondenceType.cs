using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CorrespondenceType
{
    public int CorrespondenceTypeId { get; set; }

    public Guid? Guid { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Communication> Communications { get; set; } = new List<Communication>();
}
