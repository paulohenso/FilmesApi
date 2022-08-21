using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.IService;
using Infrastructure.IRepository;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public LoginResponseDto Login(LoginRequestDto model)
        {
            var user = _userRepository.GetUserByCredencial(model.User, model.Password);

            var token = _tokenService.GenerateToken(user);
            return new LoginResponseDto { Token = token };
        }
    }
}
