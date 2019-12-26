using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Domain
{
    public class TopicLike
    {
        [Column(Order = 1)]
        public long UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        public int TopicId { get; set; }
        public TopicQuestion Topic { get; set; }
    }
}
