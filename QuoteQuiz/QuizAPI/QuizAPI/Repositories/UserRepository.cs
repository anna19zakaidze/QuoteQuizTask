using QuizAPI.Models.Entities;

namespace QuizAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> PostUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task PutUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
