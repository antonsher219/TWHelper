using Domain.Models.Identity;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain
{
    public class Topic
    {
        public int Id { get; set; }
                
        public virtual User Creator{ get; set; }

        public DateTime CreatingTime { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(150, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Theme")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(2000, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
