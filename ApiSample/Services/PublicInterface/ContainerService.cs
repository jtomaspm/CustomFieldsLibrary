using DAL;
using Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PublicInterface
{
    public class ContainerService
    { 
        public static ContainerInDepotDto? getContainerInDepot(int containerId)
        {
            using (var ctx = new DatabaseContext())
            {
                var container = ctx.Containers.FirstOrDefault(x => x.Id == containerId);
                if (container == null) return null;
                return ContainerInDepotBuilder.build(container, ctx);
            }
        }

        public static IEnumerable<ContainerDto> getAllContainers()
        {
            using (var ctx = new DatabaseContext())
                return ctx.Containers.ToList()
                    .ConvertAll(x=>ContainerDtoBuilder.build(x, ctx));
        }

    }
}
