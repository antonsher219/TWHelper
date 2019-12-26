using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum
{
    public class TopicAnswerDTO
    {
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfileImage { get; set; }
        public string Created { get; set; }
        public bool IsRigthAnswer { get; set; }
    }
}
