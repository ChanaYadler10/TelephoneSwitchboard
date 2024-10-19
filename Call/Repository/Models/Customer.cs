using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public Guid? Guid { get; set; }

    public string? Name { get; set; }

    public int? CustomerTypeTblId { get; set; }

    public string? Comments { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<CommunicationRepresentative> CommunicationRepresentatives { get; set; } = new List<CommunicationRepresentative>();

    public virtual ICollection<Communication> Communications { get; set; } = new List<Communication>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    public virtual ICollection<CustomerContactInfo> CustomerContactInfos { get; set; } = new List<CustomerContactInfo>();

    public virtual ICollection<CustomerInquiry> CustomerInquiries { get; set; } = new List<CustomerInquiry>();

    public virtual ICollection<CustomerSetting> CustomerSettings { get; set; } = new List<CustomerSetting>();

    public virtual CustomerType? CustomerTypeTbl { get; set; }

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<QualificationDegree> QualificationDegrees { get; set; } = new List<QualificationDegree>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
