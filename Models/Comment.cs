using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Topic Top { get; set; }
        public DateTime CreateTime { get; set; }
        public User Creator { get; set; }
        public string Content { get; set; }
    }
}
