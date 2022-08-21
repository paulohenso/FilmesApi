using Application.Dtos;
using Application.IService;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.QueryParams;
using Infrastructure.IRepository;

namespace Application.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;
        public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public async Task CreateAsynci(FilmeDto filmeDto)
        {
            var filme = _mapper.Map<FilmeModel>(filmeDto);
            await _filmeRepository.CreateFilmeAsync(filme);
        }

        public async Task<IEnumerable<FilmeModel>> GetFilmes(FilmeQueryParams filmeQuery)
        {
           var filmes = await _filmeRepository.GetFilmes(filmeQuery);
            
            if(!filmes.Any())
            {
                throw new BadRequestException("Não existe requisição no período selecionado");
            }

            return filmes;
        }
    }
}
