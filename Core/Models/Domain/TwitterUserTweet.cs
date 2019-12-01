using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Domain
{
    //store most positive and most negative tweets for analyzed accounts
    public class TwitterUserTweet
    {
        [Key]
        public string TwitterNick { get; set; }
        [Required]
        public string Tweet { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
