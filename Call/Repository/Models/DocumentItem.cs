using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class DocumentItem
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

    public string? ClientEmail { get; set; }

    public string? ClientAddress { get; set; }

    public string? CurrencyId { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Currency { get; set; }

    public string? Rate { get; set; }

    public string? Total { get; set; }

    public string? Totalsum { get; set; }

    public string? Discount { get; set; }

    public string? Roundup { get; set; }

    public string? Afterdiscount { get; set; }

    public string? TaxExempt { get; set; }

    public string? VatPercent { get; set; }

    public string? Totalvat { get; set; }

    public string? Totalwithvat { get; set; }

    public string? Paid { get; set; }

    public string? Totalwht { get; set; }

    public string? Totalpaid { get; set; }

    public string? Comment { get; set; }

    public string? DocTitle { get; set; }

    public string? DocUrl { get; set; }

    public string? EmployeeId { get; set; }

    public string? FactoringStatus { get; set; }

    public string? HasBarter { get; set; }

    public string? HasBt { get; set; }

    public string? HasCash { get; set; }

    public string? HasCc { get; set; }

    public string? HasCheques { get; set; }

    public string? HasHk { get; set; }

    public string? HasPp { get; set; }

    public string? Imported { get; set; }

    public string? IncomeType { get; set; }

    public string? IncomeTypeId { get; set; }

    public string? InvoiceReferenceNumber { get; set; }

    public string? IsCancellation { get; set; }

    public string? IsCancelled { get; set; }

    public string? Oprintedv2 { get; set; }

    public string? PosId { get; set; }

    public string? SalesmanId { get; set; }

    public string? UserId { get; set; }

    public string? Status { get; set; }

    public string? RemainingsumBeforeVat { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateModified { get; set; }

    public Guid Guid { get; set; }

    public int? DocumentDetailsTblId { get; set; }

    public virtual DocumentDetail? DocumentDetailsTbl { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
