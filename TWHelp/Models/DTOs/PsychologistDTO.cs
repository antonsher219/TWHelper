using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs
{
    public class PsychologistDTO
    {
        public int Age { get; set; }
        public byte[] AvatarImage { get; set; }

        public bool IsAccountActivated { get; set; }
        public string Education { get; set; }
        public string AreaOfExpertise { get; set; }
        public string WorkExperience { get; set; }

        public int Likes { get; set; }
        public bool IsCurrentUserSetLike { get; set; }
    }
}
