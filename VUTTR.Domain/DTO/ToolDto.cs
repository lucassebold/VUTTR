using System.Collections.Generic;
using VUTTR.Domain.Entities.Tags;

namespace VUTTR.Domain.DTO
{
    public class ToolDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public Guid? Codigo {  get; set; }
    }
}
