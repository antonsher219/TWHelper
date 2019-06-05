using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class User : IdentityUser<long>
    {
        public string Nickname { get; set; }
    }
}
    