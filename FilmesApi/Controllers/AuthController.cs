using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost]
        public LoginResponseDto Login([FromBody] LoginRequestDto model)
        {
            return _authService.Login(model);
        }
    }
}
