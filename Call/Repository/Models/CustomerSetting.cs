using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CustomerSetting
{
    public int SetupId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? SetupName { get; set; }

    public string? SetupValue { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
