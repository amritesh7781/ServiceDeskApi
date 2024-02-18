using System;
using System.Collections.Generic;

namespace ServiceDeskApi.Models;

public partial class StatusTable
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TicketTable> TicketTables { get; set; } = new List<TicketTable>();
}
