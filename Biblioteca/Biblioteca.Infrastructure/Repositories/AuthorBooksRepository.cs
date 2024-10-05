using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class AuthorBooksRepository : IAuthorBooksRepository
    {
        private readonly BibliotecaContext _context;

        public AuthorBooksRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task Create(List<AuthorBooks> authorBooks, CancellationToken cancellationToken)
        {
            _context.AuthorBooks.AddRange(authorBooks);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(AuthorBooks authorBooks, CancellationToken cancellationToken)
        {
            authorBooks.IsDeleted = true;
            authorBooks.DeletedAt = DateTime.Now;
            _context.AuthorBooks.Update(authorBooks);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<AuthorBooks?> Find(int Id, CancellationToken cancellationToken)
        {
            return await _context.AuthorBooks.IgnoreAutoIncludes().FirstOrDefaultAsync(ab => ab.Id == Id, cancellationToken);
        }

        public async Task<AuthorBooks?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.AuthorBooks
                .Include(ab => ab.Book)
                .Include(ab => ab.Author)
                .FirstOrDefaultAsync(ab => ab.Id == Id, cancellationToken);
        }

        public async Task<bool> IsExists(int IdBook, int IdAuthor, CancellationToken cancellationToken)
        {
            return await _context.AuthorBooks.AnyAsync(ab => ab.IdBook == IdBook && ab.IdAuthor == IdAuthor, cancellationToken);
        }

        public async Task Update(AuthorBooks authorBooks, CancellationToken cancellationToken)
        {
            authorBooks.UpdatedAt = DateTime.Now;
            _context.AuthorBooks.Update(authorBooks);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
