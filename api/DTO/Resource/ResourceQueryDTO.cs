using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace api.DTO.Resource;

public class ResourceQueryDto
{
    public string SearchValue { get; set; }
    public string SortColumn { get; set; }
    public string SortOrder { get; set; }

    [AllowNull]
    public int PageNumber { get; set; }

    [AllowNull]
    public int PageSize { get; set; }

    [AllowNull]
    [DefaultValue(false)]
    public bool IncludeDeleted { get; set; }
    [AllowNull]
    [DefaultValue(false)]
    public bool IsInactive { get; set; }
    public DateTime Week { get; set; }
    public int Page { get; set; }
    public string Search { get; set; }
    public Guid? SolutionDeliveryLeaderID { get; set; }
    public Guid? ResourceLocationID { get; set; }
    public Guid CustomerID { get; set; }
    public Guid ProjectID { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string projects { get; set; }
    public string BusinessUnitID { get; set; }
    [AllowNull]
    public List<Guid> SolutionDeliveryLeaderIDs { get; set; } = new List<Guid>();

    [AllowNull]
    public List<Guid> CustomerIDs { get; set; } = new List<Guid>();

    [AllowNull]
    public List<Guid> ProjectIDs { get; set; } = new List<Guid>();

    [AllowNull]
    public List<string> BusinessUnitIDs { get; set; } = new List<string>();
    [DefaultValue(false)]
    public bool IsResourceView { get; set; } = false;
}