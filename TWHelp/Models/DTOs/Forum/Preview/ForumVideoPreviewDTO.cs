using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum.Preview
{
    public class ForumVideoPreviewDTO 
    {
        public int ForumVideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string CreatedDateString { get; set; }
        public string CreatedTimeString { get; set; }
        public string UserName { get; set; }
    }
}
