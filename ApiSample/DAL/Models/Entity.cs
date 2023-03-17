using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<Container> Containers { get; } = new List<Container>();

    public virtual ICollection<Depot> Depots { get; } = new List<Depot>();

    public virtual EntityType TypeNavigation { get; set; } = null!;
}
