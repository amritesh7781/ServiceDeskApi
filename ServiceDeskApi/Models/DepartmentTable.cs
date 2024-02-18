using System;
using System.Collections.Generic;

namespace ServiceDeskApi.Models;

public partial class DepartmentTable
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<GroupTable> GroupTables { get; set; } = new List<GroupTable>();

    public virtual ICollection<TicketTable> TicketTables { get; set; } = new List<TicketTable>();

    public virtual ICollection<UserTable> UserTables { get; set; } = new List<UserTable>();
}
