using Domain.Models;
using Domain.QueryParams;

namespace Infrastructure.IRepository
{
    public interface IFilmeRepository
    {
        Task CreateFilmeAsync(FilmeModel filme);
        Task<IEnumerable<FilmeModel>> GetFilmes(FilmeQueryParams filmeQuery);
    }
}
