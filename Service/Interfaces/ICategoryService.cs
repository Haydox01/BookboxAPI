using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;

namespace Bookbox.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createCategoryDto);
    }
}
