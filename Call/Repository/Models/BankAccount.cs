using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class BankAccount
{
    public int BankAccountId { get; set; }

    public string BankName { get; set; } = null!;

    public string? Branch { get; set; }

    public string? AccountNumber { get; set; }

    public string? BankRoutingNumber { get; set; }

    public string? Iban { get; set; }

    public string? Swiftcode { get; set; }

    public int? CustomerId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }
}
