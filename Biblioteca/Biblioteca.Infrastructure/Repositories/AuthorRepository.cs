using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Biblioteca.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BibliotecaContext _context;

        public AuthorRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task DeleteAuthor(Author author, CancellationToken cancellationToken)
        {
            author.IsDeleted = true;
            author.DeletedAt = DateTime.Now;

            _context.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAuthors(CancellationToken cancellationToken)
        {
            return await _context.Authors
                //.IgnoreAutoIncludes()
                .Where(x => !x.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<Author?> GetAuthorById(int Id, CancellationToken cancellationToken)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .ThenInclude(ab => ab.Book)
                .FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == Id, cancellationToken);

            if (author is null)
                return null;

            return author;
        }

        public async Task<Author?> GetAuthor(int Id, CancellationToken cancellationToken)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == Id, cancellationToken);
        }

        public async Task<Author> CreateAuthor(Author author, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync(cancellationToken);

                return author;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAuthor(Author author, CancellationToken cancellationToken)
        {
            try
            {
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsAuthorExists(string Name, CancellationToken cancellationToken)
        {
            return await _context.Authors.AnyAsync(a => !a.IsDeleted && string.Equals(a.Name, Name), cancellationToken);
        }

        public Author? FindAuthor(int Id)
        {
            return _context.Authors.FirstOrDefault(a => !a.IsDeleted && a.Id == Id);
        }
    }
}
