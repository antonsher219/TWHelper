using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Models.Domain
{
    public class ForumVideo
    {
        public int Id { get; set; }

        public long UploaderId { get; set; }
        public User Uploader { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string TagsString { get; set; }
        public string VideoFilePath { get; set; }
        public DateTime Created { get; set; }

        [NotMapped]
        public List<string> Tags => TagsString?.Split(',').ToList() ?? new List<string>();
    }
}
