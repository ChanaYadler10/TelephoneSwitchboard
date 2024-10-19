using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public DateTime? ExpenseDate { get; set; }

    public decimal? Amount { get; set; }

    public string? ExpenseDescription { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
