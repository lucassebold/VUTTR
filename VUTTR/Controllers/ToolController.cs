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
        public ActionResult<List<ToolDto>> List([FromQuery] List<string> tag)
        {
            return _toolApplicationService.List(tag);
        }

        [HttpPost]
        [Route("/Create")]
        public void Create(ToolRequest tool)
        {
            _toolApplicationService.Create(tool);
        }

        [HttpDelete]
        [Route("/Delete")]
        public void Delete(ToolRequest tool)
        {
            _toolApplicationService.Delete(tool);
        }
    }
}
