using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Domain
{
    public class TestResult
    {
        public int Id { get; set; }

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }

        //additional content?
        public string Content { get; set; }
    }
}
