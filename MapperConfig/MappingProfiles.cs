using AutoMapper;
using Bookbox.Models;
using Bookbox.Models.Dto;

namespace Bookbox.MapperConfig
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Mapping Models to Dto and in reverse 

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<AddBookDto, Book>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AddUpdateAuthorDto>().ReverseMap();
        }
    }
}
