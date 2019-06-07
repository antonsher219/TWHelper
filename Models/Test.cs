using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class Test
    {
        public int Id { get; set; }

        public virtual User Creator { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Theme")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(5000, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Content")]
        public string Description { get; set; }

    }
}
