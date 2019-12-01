using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class TopicPreviewDTO
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public string BackgroundImagePath { get; set; }
        public string AuthorImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumberOfReplies { get; set; }
    }
}
