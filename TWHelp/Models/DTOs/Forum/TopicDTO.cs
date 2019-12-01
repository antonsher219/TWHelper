using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class TopicDTO
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public string Author { get; set; }
        public string AuthorProfileImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
