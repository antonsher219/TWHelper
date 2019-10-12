using Domain.Models.Identity;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Domain
{
    public class Like
    {
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        public Guid PsychologistId { get; set; }
        public User Psychologist { get; set; }
    }
}
