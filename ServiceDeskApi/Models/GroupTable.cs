using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServiceDeskApi.Models;

public partial class GroupTable
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;
    [JsonIgnore]
    public int? DepartmentId { get; set; }
    [JsonIgnore]
    public virtual DepartmentTable? Department { get; set; }

    public virtual ICollection<TicketTable> TicketTables { get; set; } = new List<TicketTable>();

    public virtual ICollection<UserTable> UserTables { get; set; } = new List<UserTable>();
}
