using AutoMapper;
using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using Bookbox.Models;
using Bookbox.Repositories.Implementations;
using Bookbox.Repositories.Interfaces;
using Bookbox.Service.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookbox.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<Category> unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork<Category> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = mapper.Map<Category>(createCategoryDto);
            await unitOfWork.Repository.AddAsync(category);
            await unitOfWork.CompleteAsync();
            return mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = await unitOfWork.Repository.All();
            return mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await unitOfWork.Repository.GetByIdAsync(id);
            return mapper.Map<CategoryDto>(category);
        }
    }
}