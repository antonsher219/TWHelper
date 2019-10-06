﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Identity
{
    public class User : IdentityUser<long>
    {
        public string Nickname { get; set; }

        public int Age { get; set; }

        public byte[] AvatarImage { get; set; }

        public string About { get; set; }
    }
}