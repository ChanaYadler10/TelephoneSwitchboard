using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class MarketingCampaign
{
    public int MarketingCampaignId { get; set; }

    public Guid? Guid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public int? MarketingCampaignStatusTblId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual MarketingCampaignStatus? MarketingCampaignStatusTbl { get; set; }
}
