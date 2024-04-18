using AutoMapper;
using Bookbox.Data;
using Bookbox.Models;
using Bookbox.Models.Dto;
using Bookbox.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase

    {
        private readonly BookBoxDbContext dbContext;
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorController(BookBoxDbContext dbContext, IAuthorRepository authorRepository, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }


        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AuthorDto authorDto)
        {
            if( !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var author = mapper.Map<Author>(authorDto);
                await authorRepository.CreateAuthor(author);
            }
        }

    }
}
