using Application.Dtos;
using Domain.Models;
using Domain.QueryParams;

namespace Application.IService
{
    public interface IFilmeService
    {
        Task CreateAsynci(FilmeDto filme);
        Task<IEnumerable<FilmeModel>> GetFilmes(FilmeQueryParams filmeQuery);
    }
}
