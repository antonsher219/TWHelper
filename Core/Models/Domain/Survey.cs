using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class Survey
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string AccountKey { get; set; }
        public string SurveyJson { get; set; }
    }
}
