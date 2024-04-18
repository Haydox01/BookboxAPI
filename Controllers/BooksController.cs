using AutoMapper;
using Bookbox.Data;
using Bookbox.Models;
using Bookbox.Models.Dto;
using Bookbox.Repositories;
using Bookbox.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;
        private readonly BookBoxDbContext dbContext;

        public BooksController(IMapper mapper, IBookRepository bookRepository, BookBoxDbContext dbContext)
        {
            this.mapper = mapper;
            this.bookRepository = bookRepository;
            this.dbContext = dbContext;
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AddBookDto addBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            try
            {
                var book = mapper.Map<Book>(addBookDto);
                book = await bookRepository.AddBook(book);

                var bookDto = mapper.Map<BookDto>(book);

                return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }
            
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? title, [FromQuery] string? author)
        {
            if(string.IsNullOrEmpty(title)  == false)
            {
                try
                {
                    var bookTitle = await bookRepository.GetBooksByTitle(title);
                 /*   if (bookTitle == null || bookTitle.Count == 0)
                    {
                        return NotFound();
                    }*/
                    return Ok(mapper.Map<List<BookDto>>(bookTitle));
                }
               
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred. Please try again later.(TITLE)");
                }

            }

            if (string.IsNullOrEmpty(author) == false)
            {
                try
                {
                    var books = await bookRepository.GetBooksByAuthorName(author);
                 /*   if (books == null || books.Count == 0)
                    {
                        return NotFound();
                    }*/

                    var bookDtos = mapper.Map<List<BookDto>>(books);
                    return Ok(bookDtos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred. Please try again later.");
                }

            }

            try
            {

                var books = await bookRepository.GetAllBooks();
                if (books.Count == 0)
                {
                    return NotFound("No books found.");
                }
                return Ok(books);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            try
            {

                var book = mapper.Map<Book>(updateBookDto);
                book = await bookRepository.UpdateBook(id, book);
                if (book == null)
                {
                    return NotFound();
                }
                await dbContext.SaveChangesAsync();
                return Ok(mapper.Map<BookDto>(book));
            }
            catch (Exception ex)
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
                var book = await bookRepository.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<BookDto>(book));
            } catch (Exception ex)
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
                var book = await bookRepository.DeleteBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<BookDto>(book));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");

            }
        }
    }
}
