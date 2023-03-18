using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Dtos
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
    }

    public static class EntityDtoBuilder
    {
        public static EntityDto build(Entity entity)
        {
            return new EntityDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
            };
        }
    }
}
