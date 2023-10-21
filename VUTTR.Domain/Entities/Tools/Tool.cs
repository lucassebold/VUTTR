using System;
using System.Collections.Generic;

namespace VUTTR.Domain.Entities.Tools
{
    public class Tool
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
    }
}
