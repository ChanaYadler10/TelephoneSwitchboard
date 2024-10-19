using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public Guid? Guid { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
