using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CustomerContactInfo
{
    public int CustomerContactInfoId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public int? ContactInfoTblId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ContactInfo? ContactInfoTbl { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
