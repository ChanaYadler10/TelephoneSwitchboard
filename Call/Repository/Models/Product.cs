using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? PurchaseTblId { get; set; }

    public Guid? Guid { get; set; }

    public string? ProductName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Purchase? PurchaseTbl { get; set; }
}
