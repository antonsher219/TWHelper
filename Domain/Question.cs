﻿
namespace Domain.Models.Domain
{
    public class Question
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Test Test { get; set; }
    }
}
