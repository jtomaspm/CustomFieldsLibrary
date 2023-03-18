using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Dtos
{
    public class ContainerDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string ContainerType { get; set; }

        public string Owener { get; set; }

        public string Depot { get; set; }
    }

    public static class ContainerDtoBuilder
    {
        public static ContainerDto build(Container container, DatabaseContext ctx)
        {
            var cid = ContainerInDepotBuilder.build(container, ctx);
            return new ContainerDto()
            {
                Id = container.Id,
                Code = container.Code,
                ContainerType = ctx.ContainerTypes.First(x=>x.Id == container.ContainerTypeId).Name,
                Depot = cid?.Depot ?? "",
                Owener = ctx.Entities.First(x=>x.Id==container.OwenerId).Name,
            };
        }
    }
}
