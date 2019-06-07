using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models
{
    public class Answer
    {
        public int Id { get; set; } 
        public string _Answer { get; set; } 
        public int Note { get; set; }
        public Question _Question { get; set; }
    }
}
