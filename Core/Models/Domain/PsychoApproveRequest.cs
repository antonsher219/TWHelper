using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class PsychoApproveRequest
    {
        public int Id { get; set; }

        public long PsychoId { get; set; }
        public User Psycho { get; set; }

        public string DiplomaPath { get; set; }
        //additional fields
    }
}
