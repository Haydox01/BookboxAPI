using AutoMapper;
using Bookbox.Data;
using Bookbox.Models;
using Bookbox.Models.Dto;
using Bookbox.Repositories;
using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
      //  [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Add([FromBody] AddUpdateAuthorDto addUpdateAuthorDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = mapper.Map<Author>(addUpdateAuthorDto);
                    author = await authorRepository.CreateAuthor(author);
                    var AuthorDTO = mapper.Map<AuthorDto>(author);
                    return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred. Please try again later.");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
           
         }

      
        [HttpGet]
       // [Authorize(Roles ="Admin, Editor, Customer")]
        public async Task<IActionResult> Get([FromQuery] string? name)
        {
           

            if (string.IsNullOrEmpty(name) == false)
            {
                try
                {
                    var authorName = authorRepository.GetAuthorsByName(name);
                    return Ok(mapper.Map<List<AuthorDto>>(authorName));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred. Please try again later.");
                }
            }
            try
            {
                var authors = await authorRepository.GetAllAuthors();
                if (authors.Count == 0)
                {
                    return NotFound("No Author Found");
                }
                return Ok(authors);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var author = await authorRepository.GetAuthorsById(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<AuthorDto>(author));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }

        }
        [HttpPut]
        [Route("{id:Guid}")]
       // [Authorize(Roles ="Editor")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddUpdateAuthorDto addUpdateAuthorDto)
        {
            try
            {
                var author = mapper.Map<Author>(addUpdateAuthorDto);
                author = await authorRepository.UpdateAuthor(id, author);
                if (author == null)
                {
                    return NotFound();
                }
                await dbContext.SaveChangesAsync();
                return Ok(mapper.Map<AuthorDto>(author));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var author = await authorRepository.DeleteAuthorById(id);
                if(author == null)
                {
                    return NotFound();

                }
                return Ok(mapper.Map<AuthorDto>(author));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }
        }





    }
}
