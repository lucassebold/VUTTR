using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUTTR.Domain.DTO;
using VUTTR.Domain.Entities.Tools;

namespace VUTTR.Domain.Interfaces.Repositories
{
    public interface IToolRepository
    {
        List<ToolDto> List(string tag);
    }
}
