using Microsoft.AspNetCore.Mvc;
using pr11.DTOs;
using pr11.Models;
using pr11.Services;

namespace pr11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId
            };

            var createdBook = _bookService.AddBook(book);

            return CreatedAtAction(nameof(GetById),
                new { id = createdBook.Id }, createdBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}