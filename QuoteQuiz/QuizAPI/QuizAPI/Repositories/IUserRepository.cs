using QuizAPI.Models.Entities;

namespace QuizAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task PutUser(int id, User user);
        Task<User> PostUser(User user);
        Task DeleteUser(int id);

    }
}
