using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public Book CreateBook(Book book)
        {
            _manager.Book.CreateBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetBookById(id, trackChanges);
            if (entity is null) throw new BookNotFoundException(id: id);

            _manager.Book.DeleteBook(entity);
            _manager.Save();
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books = _manager.Book.GetAllBooks(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public Book GetBookById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetBookById(id, trackChanges);

            if (book is null) throw new BookNotFoundException(id: id);
            return book;
        }

        public void UpdateBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.Book.GetBookById(id, trackChanges);

            if (entity is null) throw new BookNotFoundException(id: id);
            if (bookDto is null) throw new ArgumentNullException(nameof(bookDto));

            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.UpdateBook(entity);
            _manager.Save();
        }
    }
}
