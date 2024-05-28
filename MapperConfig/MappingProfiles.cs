﻿using AutoMapper;
using Bookbox.Dto;
using Bookbox.Models;

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
