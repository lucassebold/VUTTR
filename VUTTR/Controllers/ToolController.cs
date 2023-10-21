using API.Services.ApplicationService;
using Microsoft.AspNetCore.Mvc;
using VUTTR.Domain.DTO;

namespace API.Controllers
{
    public class ToolController : Controller
    {
        private readonly ToolApplicationService _toolApplicationService;
        public ToolController(ToolApplicationService toolApplicationService)
        {
            _toolApplicationService = toolApplicationService;
        }

        [HttpGet]
        [Route("/Tools")]
        public ActionResult<List<ToolDto>> List([FromQuery] string tag)
        {
            return _toolApplicationService.List(tag);
        }
    }
}
