using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public byte[] AvatarImage { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
