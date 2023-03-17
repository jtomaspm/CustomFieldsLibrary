using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ContainerType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Size { get; set; }

    public virtual ICollection<Container> Containers { get; } = new List<Container>();
}
