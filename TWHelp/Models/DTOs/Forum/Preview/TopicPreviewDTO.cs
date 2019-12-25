using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum.Preview
{
    public class TopicPreviewDTO
    {
        public int TopicId { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public string Created { get; set; }
        public int NumberOfReplies { get; set; }
    }
}
