using DAL;
using Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PublicInterface
{
    internal class ContainerService
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

    }
}
