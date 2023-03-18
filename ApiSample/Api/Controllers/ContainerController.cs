using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Services.Models.Dtos;
using Services.PublicInterface;

namespace Api.Controllers
{
    public class ContainerController : Controller
    {
        [Route("/api/Container")]
        [EnableQuery]
        [HttpGet]
        public IEnumerable<ContainerDto> getContainers()
        {
            return ContainerService.getAllContainers();
        }

        [Route("/api/Container/{id}")]
        [HttpGet]
        public ContainerFullDetailsDto? getDepotFullInfo(int id)
        {
            return ContainerService.GetContainerFullDetails(id);
        }
    }
}
