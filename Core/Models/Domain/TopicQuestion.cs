using Domain.Models.Identity;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain
{
    public class TopicQuestion
    {
        public int Id { get; set; }

        public long CreatorId { get; set; }
        public virtual User Creator { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(150, ErrorMessage = "{0} is too long.")]
        public string Header { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(2000, ErrorMessage = "{0} is too long.")]
        public string Content { get; set; }
        
        public DateTime Created { get; set; }
    }
}
