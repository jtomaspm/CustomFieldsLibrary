using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Container
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int ContainerTypeId { get; set; }

    public int OwenerId { get; set; }

    public virtual ContainerType ContainerType { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; } = new List<Operation>();

    public virtual Entity Owener { get; set; } = null!;
}
