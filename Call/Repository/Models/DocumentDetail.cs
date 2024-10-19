using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class DocumentDetail
{
    public int Id { get; set; }

    public string? Doctype { get; set; }

    public string? Docnum { get; set; }

    public DateOnly? Dateissued { get; set; }

    public string? Timeissued { get; set; }

    public string? ClientId { get; set; }

    public string? CustomClientId { get; set; }

    public string? ClientIdno { get; set; }

    public string? ClientName { get; set; }

    public string? ClientAddress { get; set; }

    public string? CurrencyId { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Currency { get; set; }

    public string? Rate { get; set; }

    public string? Total { get; set; }

    public string? Totalsum { get; set; }

    public string? Roundup { get; set; }

    public string? Afterdiscount { get; set; }

    public string? TaxExempt { get; set; }

    public string? VatPercent { get; set; }

    public string? Totalvat { get; set; }

    public string? Totalwithvat { get; set; }

    public string? AgentId { get; set; }

    public string? CancellationReason { get; set; }

    public string? Comment { get; set; }

    public string? DocTitle { get; set; }

    public string? DocUrl { get; set; }

    public string? EmployeeId { get; set; }

    public string? FactoringStatus { get; set; }

    public string? Hwc { get; set; }

    public string? Imported { get; set; }

    public string? IncomeType { get; set; }

    public string? IncomeTypeId { get; set; }

    public string? InternalComments { get; set; }

    public string? InvoiceReferenceNumber { get; set; }

    public string? IsCancellable { get; set; }

    public string? IsCancellation { get; set; }

    public string? IsCancelled { get; set; }

    public string? Lang { get; set; }

    public DateOnly? Paydate { get; set; }

    public string? PosId { get; set; }

    public string? Remainingsum { get; set; }

    public string? SalesmanId { get; set; }

    public string? SelfInvoice { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Status { get; set; }

    public string? TotalsumExempt { get; set; }

    public string? UserId { get; set; }

    public string? VatId { get; set; }

    public string? RemainingsumBeforeVat { get; set; }

    public int CustomerTblId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly DateModified { get; set; }

    public Guid Guid { get; set; }

    public virtual Customer CustomerTbl { get; set; } = null!;

    public virtual ICollection<DocumentItem> DocumentItems { get; set; } = new List<DocumentItem>();
}
