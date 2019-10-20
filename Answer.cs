
namespace Domain.Models.Domain
{
    public class Answer
    {
        public int Id { get; set; } 
        public string Content { get; set; } 
        public int Note { get; set; }
        public Question Question { get; set; }
    }
}
