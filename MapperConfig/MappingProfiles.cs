using AutoMapper;
using Bookbox.Models;
using Bookbox.Models.Dto;

namespace Bookbox.MapperConfig
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
