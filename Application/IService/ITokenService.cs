using Domain.Models;
using System.Security.Claims;

namespace Application.IService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
