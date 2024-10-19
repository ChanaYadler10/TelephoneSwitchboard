using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Connection
{
    public int ConnectionId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public int? RelatedCustomerTblId { get; set; }

    public int? ConnectionTypeTblId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ContactInfo? ConnectionTypeTbl { get; set; }
}
