using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthor(Author author, CancellationToken cancellationToken);
        Task<Author> GetAuthorById(int Id, CancellationToken cancellationToken);
        Task<Author> GetAuthor(int Id, CancellationToken cancellationToken);
        Author FindAuthor(int Id);
        Task UpdateAuthor(Author author, CancellationToken cancellationToken);
        Task DeleteAuthor(Author author, CancellationToken cancellationToken);
        Task<bool> IsAuthorExists(string Name, CancellationToken cancellationToken);
        Task<List<Author>> GetAllAuthors(CancellationToken cancellationToken);
    }
}
