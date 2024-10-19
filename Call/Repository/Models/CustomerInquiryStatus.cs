using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CustomerInquiryStatus
{
    public int CustomerInquiryStatusId { get; set; }

    public Guid? Guid { get; set; }

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<CustomerInquiry> CustomerInquiries { get; set; } = new List<CustomerInquiry>();
}
