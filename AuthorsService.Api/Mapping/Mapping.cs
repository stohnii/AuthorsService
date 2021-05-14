using AuthorsService.BAL.DTOs;
using AuthorsService.DAL.Entities;
using AutoMapper;

namespace AuthorsService.Api.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
