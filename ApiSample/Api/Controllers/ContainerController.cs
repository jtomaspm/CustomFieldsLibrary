using Microsoft.AspNetCore.Mvc;
using Services.Models.Dtos;
using Services.PublicInterface;

namespace Api.Controllers
{
    public class ContainerController : Controller
    {
        [Route("/api/Container")]
        [HttpGet]
        public IEnumerable<ContainerDto> getContainers()
        {
            return ContainerService.getAllContainers();
        }
    }
}
