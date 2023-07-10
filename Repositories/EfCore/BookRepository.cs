using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EfCore
{
    internal class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);

        public void UpdateBook(Book book) => Update(book);

        public IQueryable<Book> GetAllBooks(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(b => b.Id);

        public Book GetBookById(int id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }

}