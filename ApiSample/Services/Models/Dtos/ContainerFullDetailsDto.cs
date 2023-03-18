using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Dtos
{
    public class ContainerFullDetailsDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string ContainerType { get; set; }

        public string Owner { get; set; }

        public string Depot { get; set; }
        public IEnumerable<OperationDto> operations { get; set; }
    }
    public static class ContainerFullDetailsDtoBuilder
    {
        public static ContainerFullDetailsDto build(Container container, DatabaseContext ctx) 
        { 
            var baseDto = ContainerDtoBuilder.build(container, ctx);
            return new ContainerFullDetailsDto()
            {
                Code = baseDto.Code,
                ContainerType = baseDto.ContainerType,
                Depot = baseDto.Depot,
                Owner = baseDto.Owner,
                Id = baseDto.Id,
                operations = ctx.Operations.Where(x => x.ContainerId == container.Id).ToList()
                    .ConvertAll(x=>OperationDtoBuilder.build(x,ctx))
            }; 
        }
    }
}
