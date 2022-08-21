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
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AdicionarFilme([FromBody] FilmeDto filme)
        {
            await _filmeService.CreateAsynci(filme);
            return Ok(filme);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<FilmeModel>> BuscarFilmesPorTitulo([FromQuery] FilmeQueryParams filmeQuery)
        {
            return await _filmeService.GetFilmes(filmeQuery);
        }
    }
}
