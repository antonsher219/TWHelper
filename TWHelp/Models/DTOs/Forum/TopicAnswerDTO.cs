using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class TopicAnswerDTO
    {
        public string Answer { get; set; }
        public string Author { get; set; }
        public string AuthorProfileImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
