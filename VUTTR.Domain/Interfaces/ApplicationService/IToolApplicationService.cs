using System.Collections.Generic;
using VUTTR.Domain.DTO;
using VUTTR.Domain.Entities.Tools;

namespace VUTTR.Domain.Interfaces.ApplicationService
{
    public interface IToolApplicationService
    {
        List<ToolDto> List(List<string> tag);
        public void Create(ToolRequest tool);
        public void Delete(ToolRequest tool);
    }
}
