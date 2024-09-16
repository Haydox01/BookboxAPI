using AutoMapper;
using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using Bookbox.DTOs.Shared;
using Bookbox.Models;
using Bookbox.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(ApiResponse.NotFoundException("Book not found"));
            }
            /*return Ok(book);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<BookDto>(book)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBookDto addBookDto)
        {
            var book = await bookService.AddBookAsync(addBookDto);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpGet]
        [Route("authorName")]
        public async Task<IActionResult> GetBookByAuthorName([FromQuery] string authorName)
        {
            var book = await bookService.GetBookByAuthorNameAsync(authorName);
            if (book == null)
            {
                return NotFound(ApiResponse.NotFoundException("Author not found"));
            }
            /*return Ok(book);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<List<BookDto>>(book)));
        }



        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? title)
        {
            var books = await bookService.GetAllBookAsync(title);
            /*return Ok(books);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<List<BookDto>>(books)));

        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = await bookService.UpdateBookAsync(id, updateBookDto);
            if(book == null)
            {
                return NotFound(ApiResponse.NotFoundException("Book not found"));
            }
            /*return Ok(book);*/
            return Ok(ApiResponse.SuccessMessageWithData(_mapper.Map<BookDto>(book)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await bookService.DeleteBookAsync(id);
            if (book == null)
            {
                return NotFound(ApiResponse.NotFoundException("Book not found"));
            }
            /*return Ok(book);*/
            return Ok(ApiResponse.SuccessMessage("Book deleted successfully!"));
        }
    }
}