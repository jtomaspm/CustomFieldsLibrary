using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EntityType
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Entity> Entities { get; } = new List<Entity>();
}
