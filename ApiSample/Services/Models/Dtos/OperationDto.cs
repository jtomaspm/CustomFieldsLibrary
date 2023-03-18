using DAL;
using DAL.Models;
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

    public static class OperationDtoBuilder{
        public static OperationDto build(Operation operation, DatabaseContext ctx)
        {
            var depot = ctx.Depots.First(x => x.Id == operation.DepotId);
            var container = ctx.Containers.First(x=> x.Id == operation.ContainerId);
            return new OperationDto()
            {
                Client = ctx.Entities.First(x => x.Id == container.OwenerId).Name,
                Supplier = ctx.Entities.First(x => x.Id == depot.OwenerId).Name,
                Date = operation.Date,
                Container = container.Code,
                Depot = depot.Name,
                Id = operation.Id,
                OperationType = operation.OperationType
            };
        }
    }

}
