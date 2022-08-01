using Microsoft.EntityFrameworkCore;
using QuizAPI.Models.Entities;

namespace QuizAPI.Data
{
    public class QuizDbContext:DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserGivenQuestion> UserGivenQuestions { get; set; }
    }
}
