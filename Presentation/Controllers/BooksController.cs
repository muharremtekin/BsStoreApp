using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _manager.BookService.GetAllBooks(trackChanges: false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager
                .BookService
                .GetBookById(id: id, trackChanges: false);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book is null)
                return BadRequest();
            _manager.BookService.CreateBook(book);


            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest();

            _manager.BookService.UpdateBook(id: id, bookDto: bookDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteBook(id: id, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = _manager.BookService.GetBookById(id: id, trackChanges: true);

            bookPatch.ApplyTo(entity);
            _manager.BookService
                .UpdateBook(
                id: id,
                bookDto:
                new BookDtoForUpdate(entity.Id, entity.Title, entity.Price),
                trackChanges: true);

            return NoContent();
        }
    }
}
