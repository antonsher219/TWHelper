using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class ForumVideoDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags  { get; set; }
    }
}
