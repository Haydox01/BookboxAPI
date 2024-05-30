using AutoMapper;
using Bookbox.Data;
using Bookbox.Dto;
using Bookbox.DTOs;
using Bookbox.Models;
using Bookbox.Repositories;
using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;
using Bookbox.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorsController : ControllerBase

    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? name)
        {
            var authors = await authorService.GetAllAuthorAsync(name);
            return Ok(authors);

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
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var author = await authorService.UpdateAuthorAsync(id, updateAuthorDto);
            return Ok(author);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await authorService.DeleteAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}


