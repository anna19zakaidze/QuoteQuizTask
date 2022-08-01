using QuizAPI.Models.Entities;
using QuizAPI.Models.Helpers;

namespace QuizAPI.Repositories
{
    public interface IQuestionsRepository
    {
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestionById(int id);
        Task PutQuestion(int id, Question question);
        Task<Question> PostQuestion(Question question);
        Task DeleteQuestion(int id);
        Task<Boolean> QuestionExists(int id);
    }
}
