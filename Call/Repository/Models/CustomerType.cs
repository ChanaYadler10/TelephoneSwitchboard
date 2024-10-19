using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CustomerType
{
    public int CustomerTypeId { get; set; }

    public Guid? Guid { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
