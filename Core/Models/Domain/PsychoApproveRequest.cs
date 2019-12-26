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
        public DateTime Created { get; set; }

        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string DegreeDiplomaFilePath { get; set; }
        public string PhDDiplomaFilePath { get; set; }
        public string ResearchDiplomaFilePath { get; set; }
    }
}
