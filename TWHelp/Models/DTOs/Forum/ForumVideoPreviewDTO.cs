using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class ForumVideoPreviewDTO 
    {
        public int ForumVideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }
    }
}
