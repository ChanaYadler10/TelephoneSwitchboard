using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class AccountingDetail
{
    public int Code { get; set; }

    public int? ClientId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public decimal? InitialBalance { get; set; }

    public string? TermsOfPayment { get; set; }

    public DateOnly? BalanceUpdatedDate { get; set; }

    public bool EnableDigitalSignature { get; set; }
}
