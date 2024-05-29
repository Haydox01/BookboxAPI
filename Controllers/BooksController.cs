using Bookbox.Dto;
using Bookbox.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? title)
        {
            var books = await bookService.GetAllBookAsync(title);
            return Ok(books);
        
        }

        [HttpGet]
        public async Task<IActionResult> GetByAuthorName([FromQuery] string? authorName)
        {
            var books = await bookService.GetBookByAuthorNameAsync(authorName);
            return Ok(books);
        
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBookDto addBookDto)
        {
            var book = await bookService.AddBookAsync(addBookDto);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = await bookService.UpdateBookAsync(id, updateBookDto);
            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await bookService.DeleteBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}