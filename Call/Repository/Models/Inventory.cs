using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Inventory
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string UnitMeasure { get; set; } = null!;

    public decimal Price { get; set; }

    public string Currency { get; set; } = null!;

    public decimal PriceBeforeTax { get; set; }

    public string Warehouse { get; set; } = null!;

    public int Quantity { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public int MinimumStock { get; set; }

    public string? Certification { get; set; }

    public string? BatchNumber { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? Guid { get; set; }

    public int? DocumentItemTblId { get; set; }

    public virtual DocumentItem? DocumentItemTbl { get; set; }
}
