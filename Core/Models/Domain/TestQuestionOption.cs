using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class TestQuestionOption
    {
        public int Id { get; set; }

        public int TestQuestionId { get; set; }
        public TestQuestion TestQuestion { get; set; }

        public string Option { get; set; }
        public bool IsAnswer { get; set; }
    }
}
