using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain
{
    public class TwitterUserStatistic
    {
        [Key]
        public string TwitterNick { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public double GoodEmotionRate { get; set; }
        public double BadEmotionRate { get; set; }
    }
}
