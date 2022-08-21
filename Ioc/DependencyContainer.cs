using Application.IService;
using Application.Service;
using Infrastructure.Database.Context;
using Infrastructure.IRepository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Data
            services.AddScoped<SqliteContext>();

            //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();

            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}