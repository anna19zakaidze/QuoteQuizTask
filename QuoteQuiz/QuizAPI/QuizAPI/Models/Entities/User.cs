using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool? IsDisabled { get; set; }
        public List<Achievement>? Achievements { get; set; }
    }
}
