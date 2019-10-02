using Domain.Models.Identity;

using System;

namespace Domain.Models.Domain
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
