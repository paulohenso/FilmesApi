using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class FilmesProfile : Profile
    {
        public FilmesProfile()
        {
            CreateMap<FilmeDto, FilmeModel>();
        }
    }
}
