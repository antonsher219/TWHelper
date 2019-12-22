using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class ForumVideo
    {
        public string Id { get; set; }

        public long UploaderId { get; set; }
        public User Uploader { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoFilePath { get; set; }
    }
}
