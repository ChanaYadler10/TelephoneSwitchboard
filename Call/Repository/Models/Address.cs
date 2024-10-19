using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Address1 { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
