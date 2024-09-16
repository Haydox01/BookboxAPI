using AutoMapper;
using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using Bookbox.DTOs.Shared;
using Bookbox.Service.Implementations;
using Bookbox.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await service.GetCategoryByIdAsync(id);
            if(category == null)
            {
                return NotFound(ApiResponse.NotFoundException("Category not found"));
            }
            return Ok(ApiResponse.SuccessMessageWithData(mapper.Map<CategoryDto>(category)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var category = await service.AddCategoryAsync(createCategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await service.GetAllCategoryAsync();
            return Ok(ApiResponse.SuccessMessageWithData(mapper.Map<List<CategoryDto>>(categories)));
        }
    }
}