using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ContactInfo
{
    public int ContactInfoId { get; set; }

    public Guid? Guid { get; set; }

    public string? InfoType { get; set; }

    public string? Info { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<CustomerContactInfo> CustomerContactInfos { get; set; } = new List<CustomerContactInfo>();
}
