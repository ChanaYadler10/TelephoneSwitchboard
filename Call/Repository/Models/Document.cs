using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public Guid? Guid { get; set; }

    public int? CommunicationTblId { get; set; }

    public string? DocumentPath { get; set; }

    public int? DocumentTypeTblId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Communication? CommunicationTbl { get; set; }

    public virtual DocumentType? DocumentTypeTbl { get; set; }
}
