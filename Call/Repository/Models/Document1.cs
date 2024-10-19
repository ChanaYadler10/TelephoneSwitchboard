using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Document1
{
    public int DocumentId { get; set; }

    public string? DocumentNumber { get; set; }

    public DateTime? Date { get; set; }

    public string? AdditionalDetails { get; set; }

    public decimal? AmountBeforeVat { get; set; }

    public decimal? Vatamount { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Extra { get; set; }
}
