using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Operation
{
    public int Id { get; set; }

    public int ContainerId { get; set; }

    public string OperationType { get; set; } = null!;

    public int DepotId { get; set; }

    public DateTime Date { get; set; }

    public virtual Container Container { get; set; } = null!;

    public virtual Depot Depot { get; set; } = null!;

    public virtual OperationType OperationTypeNavigation { get; set; } = null!;
}
