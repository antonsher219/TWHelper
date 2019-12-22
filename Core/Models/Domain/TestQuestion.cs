using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class TestQuestion
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int OrderNumber { get; set; }
        public string Question { get; set; }
    }
}
