using AspNetCore.IQueryable.Extensions;
using Domain.Models;
using Domain.QueryParams;
using Infrastructure.Database.Context;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly SqliteContext _sqliteContext;

        public FilmeRepository(SqliteContext sqliteContext)
        {
            _sqliteContext = sqliteContext;
        }

        public async Task CreateFilmeAsync(FilmeModel filme)
        {
            await _sqliteContext.AddAsync(filme);
            await _sqliteContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmeModel>> GetFilmes(FilmeQueryParams filmeQuery)
        {
            return await _sqliteContext.Filmes.Where(
                f => f.Titulo.Contains(filmeQuery.Titulo))
                .Skip((filmeQuery.Pagina - 1) * filmeQuery.Limite)
                .Take(filmeQuery.Limite)                
                .ToListAsync();
        }
    }
}
