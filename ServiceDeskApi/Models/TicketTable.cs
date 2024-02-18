using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServiceDeskApi.Models;

public partial class TicketTable
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    [JsonIgnore]
    public int? CreatorUserId { get; set; }
    [JsonIgnore]
    public int? AssignedToUserId { get; set; }
    [JsonIgnore]
    public int? DepartmentId { get; set; }
    [JsonIgnore]
    public int? GroupId { get; set; }
    [JsonIgnore]
    public int? StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    [JsonIgnore]
    public virtual UserTable? AssignedToUser { get; set; }
    [JsonIgnore]
    public virtual UserTable? CreatorUser { get; set; }
    [JsonIgnore]
    public virtual DepartmentTable? Department { get; set; }
    [JsonIgnore]
    public virtual GroupTable? Group { get; set; }
    [JsonIgnore]
    public virtual StatusTable? Status { get; set; }
}
