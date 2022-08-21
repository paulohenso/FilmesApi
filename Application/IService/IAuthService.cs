using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.IService
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto model);
    }
}
