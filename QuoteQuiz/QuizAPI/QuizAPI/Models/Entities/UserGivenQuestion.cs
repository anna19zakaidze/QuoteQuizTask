using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Entities
{
    public class UserGivenQuestion
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
