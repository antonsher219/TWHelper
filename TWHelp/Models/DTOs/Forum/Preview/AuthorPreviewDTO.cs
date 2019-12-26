using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs.Forum.Preview
{
    public class AuthorPreviewDTO
    {
        public string AuthorName { get; set; }
        public int ActivityCount { get; set; }
        public string ProfileImageString { get; set; }
    }
}
