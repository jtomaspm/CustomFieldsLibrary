using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Dtos
{
    public class OperationDto
    {
        public int Id { get; set; }

        public string Container { get; set; }

        public string OperationType { get; set; } = null!;

        public string Depot { get; set; }

        public DateTime Date { get; set; }

        public string Client { get; set; }

        public string Supplier { get; set; }
    }
}
