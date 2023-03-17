using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Depot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int OwenerId { get; set; }

    public virtual ICollection<Operation> Operations { get; } = new List<Operation>();

    public virtual Entity Owener { get; set; } = null!;
}
