using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class Topic
    {
        public int Id { get; set; }
                
        public virtual User Creator{ get; set; }
        

        public DateTime CreatingTime { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Theme")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(1000, ErrorMessage = "{0} is too long.")]
        [Display(Name = "Content")]
        public string Content { get; set; }

    }
}
