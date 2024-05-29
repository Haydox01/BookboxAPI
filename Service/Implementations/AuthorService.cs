using AutoMapper;
using Bookbox.Dto;
using Bookbox.DTOs;
using Bookbox.Models;
using Bookbox.Repositories.Interfaces;
using Bookbox.Service.Interfaces;

namespace Bookbox.Service.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AuthorDto> AddAuthorAsync(AddAuthorDto addAuthorDto)
        {
            var author = mapper.Map<Author>(addAuthorDto);
            await unitOfWork.Authors.AddAsync(author);
            await unitOfWork.CompleteAsync();
            return mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> DeleteAuthorAsync(Guid id)
        {
            var existingAuthor = await unitOfWork.Authors.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
            return mapper.Map<AuthorDto>(existingAuthor);
        }

        public async Task<List<AuthorDto>> GetAllAuthorAsync(string name)
        {
            if (string.IsNullOrEmpty(name) == false)
            {
                var authorName = await unitOfWork.Authors.GetAuthorsByName(name);
                return mapper.Map<List<AuthorDto>>(authorName);
            }
            var authors = await unitOfWork.Authors.All();
            return mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await unitOfWork.Authors.GetByIdAsync(id);
            return mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto)
        {
            var existingAuthor = mapper.Map<Author>(updateAuthorDto);
            await unitOfWork.Authors.UpdateAuthor(id, existingAuthor);
            if (existingAuthor == null)
            {
                return null;
            }
            await unitOfWork.CompleteAsync();
            return mapper.Map<AuthorDto>(existingAuthor);
        }
    }
}
