using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Services.Models.Dtos;
using Services.PublicInterface;

namespace Api.Controllers
{
    public class DepotController : Controller
    {
        [Route("/api/Depot")]
        [EnableQuery]
        [HttpGet]
        public IEnumerable<DepotDto> getDepots()
        {
            return DepotService.getDepots();
        }

        [Route("/api/Depot/{id}")]
        [HttpGet]
        public DepotFullInfoDto? getDepotFullInfo(int id)
        {
            return DepotService.getDepotFullInfo(id);
        }
    }
}
