using Domain.Models.Identity;

using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Domain
{
    public class Test
    {
        public int Id { get; set; }

        public virtual User Creator { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(150, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Theme")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Content")]
        public string Description { get; set; }
        public string TestUrl { get; set; }
    }
}
