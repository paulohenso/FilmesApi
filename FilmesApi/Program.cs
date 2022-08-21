using FilmesApi.JwtAuth;
using FilmesApi.Swagger;
using Infrastructure.Database.Context;
using Ioc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Utility.Middleware;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

service.AddControllers();
service.AddJwtAsymmetricAuthentication();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
service
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });

DependencyContainer.RegisterServices(service);
SwaggerServiceCollection.AddSwaggerServices(service);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

try
{
    using var dbContext = new SqliteContext();
    dbContext.Database.Migrate();
}
catch (Exception e)
{
    Console.WriteLine($"Error {e.Message}");
}

app.UseHttpsRedirection();

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseMiddleware(typeof(ErrorMiddleware));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
