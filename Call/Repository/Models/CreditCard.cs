using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CreditCard
{
    public int CreditCardId { get; set; }

    public string CardNumber { get; set; } = null!;

    public string Cvv { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public string CardHolderName { get; set; } = null!;

    public int CustomerTblId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? Guid { get; set; }

    public virtual Customer CustomerTbl { get; set; } = null!;
}
