using Domain.Models;

namespace Infrastructure.IRepository
{
    public interface IUserRepository
    {
        User GetUserByCredencial(string username, string password);
    }
}
