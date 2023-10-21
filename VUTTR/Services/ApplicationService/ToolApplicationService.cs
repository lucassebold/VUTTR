using Azure;
using VUTTR.Data.Repositories;
using VUTTR.Domain.DTO;
using VUTTR.Domain.Entities.Tools;
using VUTTR.Domain.Interfaces.ApplicationService;

namespace API.Services.ApplicationService
{
    public class ToolApplicationService : IToolApplicationService
    {
        public readonly ToolRepository _toolRepository;

        public ToolApplicationService(ToolRepository toolRepository)
        {
            _toolRepository = toolRepository;
        }

        public List<ToolDto> List(string tag)
        {
            return _toolRepository.List(tag);
        }
    }
}
