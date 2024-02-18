using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServiceDeskApi.Models;

public partial class UserTable
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    [JsonIgnore]
    public int? RoleId { get; set; }
    [JsonIgnore]
    public int? DepartmentId { get; set; }
    [JsonIgnore]
    public int? GroupId { get; set; }
    [JsonIgnore]
    public virtual DepartmentTable? Department { get; set; }
    [JsonIgnore]
    public virtual GroupTable? Group { get; set; }
    [JsonIgnore]
    public virtual RoleTable? Role { get; set; }

    public virtual ICollection<TicketTable> TicketTableAssignedToUsers { get; set; } = new List<TicketTable>();

    public virtual ICollection<TicketTable> TicketTableCreatorUsers { get; set; } = new List<TicketTable>();
}
