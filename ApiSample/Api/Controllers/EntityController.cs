using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Services.Models.Dtos;
using Services.PublicInterface;

namespace Api.Controllers
{
    public class EntityController : Controller
    {
        [Route("/api/Entity")]
        [EnableQuery]
        [HttpGet]
        public IEnumerable<EntityDto> getEntities()
        {
            return EntityService.getEntities();
        }
    }
}
