using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class User : IdentityUser<long>
    {
        public string Nickname { get; set; }
        
        public int Age { get; set; }

        public byte[] AvatarImage { get; set; }
    }
}
    