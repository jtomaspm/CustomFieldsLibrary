using Microsoft.AspNetCore.Mvc;
using Services.Models.Dtos;
using Services.PublicInterface;

namespace Api.Controllers
{
    public class DepotController : Controller
    {
        [Route("/api/Depot")]
        [HttpGet]
        public IEnumerable<DepotDto> getDepots()
        {
            return DepotService.getDepots();
        }
    }
}
