using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OperationType
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; } = new List<Operation>();
}
