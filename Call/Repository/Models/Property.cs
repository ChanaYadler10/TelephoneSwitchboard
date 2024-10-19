using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? PropertyName { get; set; }

    public string? PropertyValue { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
