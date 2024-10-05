using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface IAuthorBooksRepository
    {
        Task Create(List<AuthorBooks> AuthorBooks, CancellationToken cancellationToken);
        Task Update(AuthorBooks AuthorBook, CancellationToken cancellationToken);
        Task Delete(AuthorBooks AuthorBook, CancellationToken cancellationToken);
        Task<AuthorBooks> Find(int Id, CancellationToken cancellationToken);
        Task<AuthorBooks> FindDetail(int Id, CancellationToken cancellationToken);
        Task<bool> IsExists(int IdBook, int IdAuthor, CancellationToken cancellationToken);
    }
}
