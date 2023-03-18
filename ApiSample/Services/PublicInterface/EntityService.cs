using DAL;
using Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PublicInterface
{
    public static class EntityService
    {
        public static IEnumerable<EntityDto> getEntities()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Entities.ToList().ConvertAll(x=>EntityDtoBuilder.build(x));
            }
        }
    }
}
