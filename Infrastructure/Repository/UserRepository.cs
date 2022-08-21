using Domain.Models;
using Infrastructure.Database.Context;
using Infrastructure.IRepository;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqliteContext _sqliteContext;

        public UserRepository(SqliteContext sqliteContext)
        {
            _sqliteContext = sqliteContext;
        }

        public User GetUserByCredencial(string username, string password)
        {
            var user = _sqliteContext.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user == null)
                throw new Exception("Usuário não encontrado");
            return user;
        }
    }
}
