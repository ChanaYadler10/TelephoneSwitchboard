using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ServiceRequest
{
    public int ServiceRequestId { get; set; }

    public Guid? Guid { get; set; }

    public int? CustomerTblId { get; set; }

    public string? RequestType { get; set; }

    public string? Description { get; set; }

    public int? ServiceRequestStatusTblId { get; set; }

    public string? AssignedTo { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Customer? CustomerTbl { get; set; }

    public virtual ServiceRequestStatus? ServiceRequestStatusTbl { get; set; }
}
