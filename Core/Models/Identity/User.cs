using Domain.Models.Domain;

using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Identity
{
    //Database normalization sucks

    public class User : IdentityUser<long>
    {
        public string Nickname { get; set; }

        public int Age { get; set; }

        public byte[] AvatarImage { get; set; }

        public string About { get; set; }

        public bool IsPsychologist { get; set; }

        //PsychologistProfile account
        public bool IsAccountActivated { get; set; }
        public string Education { get; set; }
        public string AreaOfExpertise { get; set; }
        public string WorkExperience { get; set; }
    }
}
