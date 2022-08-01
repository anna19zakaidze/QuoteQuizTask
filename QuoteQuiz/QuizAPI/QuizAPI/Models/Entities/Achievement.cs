using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Entities
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }
        public List<UserGivenQuestion> GivenQuestions { get; set; }
        public List<UserAnswer> Answers { get; set; }

    }
}
