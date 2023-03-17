using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Dtos
{
    public class ContainerInDepotDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string ContainerType { get; set; }

        public string Owener { get; set; }

        public string Depot { get; set; }

        public DateTime InDate { get; set; }
    }

    internal static class ContainerInDepotBuilder{
        internal static ContainerInDepotDto? build(Container container)
        {
            Operation? lastOperation;
            using (var ctx = new DatabaseContext())
            {
                lastOperation = ctx.Operations.Where(x => x.ContainerId == container.Id).ToList().MaxBy(x => x.Date);
                if (lastOperation == null) return null;
                if (lastOperation.OperationType == "Out") return null;
                return new ContainerInDepotDto()
                {
                    Id = container.Id,
                    Code = container.Code,
                    ContainerType = ctx.ContainerTypes.First(x=>x.Id == container.ContainerTypeId).Name,
                    Depot = ctx.Depots.First(x=>x.Id == lastOperation.DepotId).Name,
                    InDate = ctx.Operations.Where(x => x.ContainerId == container.Id && x.OperationType == "In").Max(x => x.Date),
                    Owener = ctx.Entities.First(x=>x.Id == container.OwenerId).Name,
                };
            }
        }
    }
}
