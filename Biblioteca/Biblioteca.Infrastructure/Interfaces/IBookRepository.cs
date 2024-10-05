using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book, CancellationToken cancellationToken);
        Task Update(Book book, CancellationToken cancellationToken);
        Task Delete(Book book, CancellationToken cancellationToken);
        Task<List<Book>> FindAll(CancellationToken cancellationToken);
        Book FindById(int Id);
        Task<Book> Find(int Id, CancellationToken cancellationToken);
        Task<Book> FindDetail(int Id, CancellationToken cancellationToken);
        Task<bool> IsExists(string Title, CancellationToken cancellationToken);
    }
}
