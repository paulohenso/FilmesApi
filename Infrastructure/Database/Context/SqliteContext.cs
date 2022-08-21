using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Context
{
    public class SqliteContext : DbContext
    {
        public SqliteContext()
        {
        }

        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext =>
                    !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                !optionsBuilder.Options.Extensions.Any(ext =>
                    ext is not RelationalOptionsExtension && ext is not CoreOptionsExtension)))
            {
                optionsBuilder.UseSqlite(GetConnectionString("SqliteConnection"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder =
                new ConfigurationBuilder().AddJsonFile("appsettings.json", true, false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmeModel>().HasKey(m => m.Id);
            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Password = "admin",
                    Role = "Administrator"
                },
                new User
                {
                    Id = 2,
                    Name = "Guest",
                    Password = "filme123",
                    Role = "Guest"
                });

            base.OnModelCreating(builder);
        }
    }
}
