using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public Guid? Guid { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int? CustomerTblId { get; set; }

    public virtual Customer? CustomerTbl { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
