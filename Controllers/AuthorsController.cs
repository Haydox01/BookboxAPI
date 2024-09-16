using AutoMapper;
using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using Bookbox.DTOs.Shared;
using Bookbox.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorsController : ControllerBase

    {
        private readonly IAuthorService authorService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> logger;

        public AuthorsController(IAuthorService authorService, IMapper mapper, ILogger<AuthorsController> logger)
        {
            this.authorService = authorService;
            _mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? name)
        {
            var authors = await authorService.GetAllAuthorAsync(name);
            
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<List<AuthorDto>>(authors)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddAuthorDto addAuthorDto)
        {
            var author = await authorService.AddAuthorAsync(addAuthorDto);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound(ApiResponse.NotFoundException("Author not found"));
            }
            /*return Ok(author);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<AuthorDto>(author)));

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var author = await authorService.UpdateAuthorAsync(id, updateAuthorDto);
            if (author == null)
            {
                return NotFound(ApiResponse.NotFoundException("Author not found"));
            }
            /*return Ok(author);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<AuthorDto>(author)));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await authorService.DeleteAuthorAsync(id);
            if (author == null)
            {
                return NotFound(ApiResponse.NotFoundException("Author not found"));
            }
            /*return Ok(author);*/
            return Ok(ApiResponse.SuccessMessage("Author deleted successfully!"));
        }
    }
}


