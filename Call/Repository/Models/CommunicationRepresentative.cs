using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class CommunicationRepresentative
{
    public int CommunicationTblId { get; set; }

    public int CustomerTblId { get; set; }

    public bool? IsMainRepresentative { get; set; }

    public int? Priority { get; set; }

    public virtual Communication CommunicationTbl { get; set; } = null!;

    public virtual Customer CustomerTbl { get; set; } = null!;
}
