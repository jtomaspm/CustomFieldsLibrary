using DAL;
using DAL.Models;
using Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PublicInterface
{
    public static class ContainerInDepotService
    {
        public static ContainerInDepotDto? getContainerInDepot(int containerId)
        {
            using (var ctx = new DatabaseContext())
            {
                var container = ctx.Containers.FirstOrDefault(x => x.Id == containerId);
                if (container == null) return null;
                return ContainerInDepotBuilder.build(container);
            }
        }

        public static IEnumerable<ContainerInDepotDto>? getDepotContainers(int depotId)
        {
            using (var ctx = new DatabaseContext())
            {
                var depot = ctx.Depots.FirstOrDefault(x => x.Id == depotId);
                if (depot == null) return null;
                var containers = new List<ContainerInDepotDto>();
                var operationsByContainer = depot.Operations.GroupBy(x => x.ContainerId);
                foreach (var operation in operationsByContainer)
                {
                    var containerInDepot = ContainerInDepotBuilder.build(operation.First().Container);
                    if (containerInDepot != null && containerInDepot.Depot == depot.Name)
                        containers.Add(containerInDepot);
                }
                return containers;
            }
        }

        public static IEnumerable<DepotDto> getDepots()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Depots.ToList().ConvertAll(x=>new DepotDto()
                {
                    Id = x.Id,
                    Location = x.Location,
                    Name = x.Name,
                    Owener = x.Owener.Name
                });
            }
        }

        public static OperationDto? DoInOperation(int depotId, int containerId)
        {
            using (var ctx = new DatabaseContext())
            using (var transaction = ctx.Database.BeginTransaction())
            {
                var depot = ctx.Depots.FirstOrDefault(x => x.Id == depotId);
                if (depot == null) return null;
                var container = ctx.Containers.FirstOrDefault(x => x.Id == containerId);
                if (container == null) return null;

                var operation = new Operation()
                {
                    ContainerId = containerId,
                    Date = DateTime.Now,
                    DepotId = depotId,
                    OperationType = "In",
                };
                ctx.Operations.Add(operation);
                ctx.SaveChanges();
                transaction.Commit();

                return new OperationDto()
                {
                    Client = container.Owener.Name,
                    Supplier = depot.Owener.Name,
                    Date = operation.Date,
                    Container = container.Code,
                    Depot = depot.Name,
                    Id = operation.Id,
                    OperationType = operation.OperationType
                };
            }
        }
    }
}
