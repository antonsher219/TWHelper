using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string _Question { get; set; }

        public Test _Test { get; set; }

    }
}
