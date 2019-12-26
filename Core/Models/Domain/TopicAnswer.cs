﻿using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Domain
{
    public class TopicAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool IsRigthAnswer { get; set; }
        public byte[] Picture { get; set; }


        public long AuthorId { get; set; }
        public User Author { get; set; }

        public int TopicId { get; set; }
        public TopicQuestion Topic { get; set; }
    }
}
