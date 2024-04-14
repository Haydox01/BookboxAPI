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

        public async Task<IActionResult> CreateBookAsync([FromBody] AddBookDto addBookDto)
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
        public async Task<IActionResult> GetAllBooks()
        {
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
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] UpdateBookDto updateBookDto)
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

        [HttpGet]
        [Route("{title}")]

        public async Task<IActionResult> GetByTitle([FromRoute] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title cannot be empty.");
            }
            try
            {
                var bookTitle = await bookRepository.GetBooksByTitle(title);
                if (bookTitle == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<BookDto>(bookTitle));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        /* [HttpGet]
         [Route("{authorName}")]
         public async Task<IActionResult> GetByAuthor([FromRoute] string authorName)
         {
             if (string.IsNullOrEmpty(authorName))
             {
                 return BadRequest("Author name cannot be empty.");
             }
             try
             {
                 var author = await bookRepository.GetBooksByAuthorName(authorName);
                 if (author == null)
                 {
                     return NotFound();
                 }
                 return Ok(mapper.Map<BookDto>(author));
             }
             catch (Exception ex)
             {
                 return StatusCode(500, "An error occurred. Please try again later.");
             }
         }*/

        [HttpGet("author/{authorName}")]
        public async Task<IActionResult> GetByAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName))
            {
                return BadRequest("Author name cannot be empty.");
            }

            try
            {
                var books = await bookRepository.GetBooksByAuthorName(authorName);
                if (books == null || books.Count == 0)
                {
                    return NotFound();
                }

                var bookDtos = mapper.Map<List<BookDto>>(books);
                return Ok(bookDtos);
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
