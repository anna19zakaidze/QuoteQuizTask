using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Entities
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }
        public string Answer { get; set; }
    }
}
