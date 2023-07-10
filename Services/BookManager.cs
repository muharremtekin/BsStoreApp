using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateBook(Book book)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            _manager.Book.CreateBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetBookById(id, trackChanges);
            if (entity == null) throw new Exception($"Book with id:{id} could not found.");

            _manager.Book.DeleteBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetBookById(id, trackChanges);
        }

        public void UpdateBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetBookById(id, trackChanges);

            if (entity == null) throw new Exception($"Book with id:{id} could not found.");
            if (book == null) throw new ArgumentNullException(nameof(book));

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.UpdateBook(entity);
            _manager.Save();
        }
    }
}
