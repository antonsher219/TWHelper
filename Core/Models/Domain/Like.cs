using Domain.Models.Identity;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain
{
    public class Like
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int PsychologistId { get; set; }
        public PsychologistProfile Psychologist { get; set; }
    }
}
