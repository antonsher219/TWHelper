using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Domain
{
    public class PsychologistProfile
    {
        [Key]
        public int PsychologistId { get; set; }

        public bool IsAccountActivated { get; set; }
        public string AreaOfExpertise { get; set; }
        public string WorkExperience { get; set; }
        public string Education { get; set; }
        public bool HasMasterDegree { get; set; }
    }
}
