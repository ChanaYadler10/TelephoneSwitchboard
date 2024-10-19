using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CustomerInquiry
{
    public int InquiryId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? InquiryType { get; set; }

    public string? Description { get; set; }

    public int? CustomerInquiryStatusTblId { get; set; }

    public string? Response { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual CustomerInquiryStatus? CustomerInquiryStatusTbl { get; set; }

    public virtual Customer? CustomerTbl { get; set; }
}
