using Application.Dtos;
using Application.IService;
using Domain.Models;
using Domain.QueryParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AdicionarFilme([FromBody] FilmeDto filme)
        {
            await _filmeService.CreateAsynci(filme);
            return Ok(filme);
        }

        [Authorize(Roles ="Administrator,Guest")]
        [HttpGet]
        public async Task<IEnumerable<FilmeModel>> BuscarFilmesPorTitulo([FromQuery] FilmeQueryParams filmeQuery)
        {
            return await _filmeService.GetFilmes(filmeQuery);
        }
    }
}
