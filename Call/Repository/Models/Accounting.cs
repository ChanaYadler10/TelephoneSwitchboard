using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Accounting
{
    public int AccountingId { get; set; }

    public decimal? Balance { get; set; }

    public decimal? Credit { get; set; }

    public decimal? Debit { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public DateOnly? ContractDate { get; set; }

    public string? TransactionType { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }
}
