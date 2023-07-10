using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.EfCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book == null)
                    return NotFound();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();
                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();

                var bookToUpdate = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (bookToUpdate == null)
                    return NotFound();

                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;

                _context.SaveChanges();
                return Ok(bookToUpdate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var bookToDelete = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (bookToDelete == null)
                    return NotFound();

                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                if (bookPatch == null)
                    return BadRequest();

                var bookToUpdate = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (bookToUpdate == null)
                    return NotFound();

                bookPatch.ApplyTo(bookToUpdate);
                _context.SaveChanges();
                return Ok(bookToUpdate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
