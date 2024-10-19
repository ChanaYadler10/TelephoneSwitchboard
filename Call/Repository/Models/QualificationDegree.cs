using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class QualificationDegree
{
    public int QualificationDegreeId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? Degree { get; set; }

    public DateTime? DateOfAttainment { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
