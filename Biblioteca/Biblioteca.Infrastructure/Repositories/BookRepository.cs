using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Biblioteca.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BibliotecaContext _context;

        public BookRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book, CancellationToken cancellationToken)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book;
        }

        public async Task Delete(Book book, CancellationToken cancellationToken)
        {
            book.IsDeleted = true;
            book.DeletedAt = DateTime.Now;
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Book?> Find(int Id, CancellationToken cancellationToken)
        {
            return await _context.Books.FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == Id, cancellationToken);
        }

        public async Task<List<Book>> FindAll(CancellationToken cancellationToken)
        {
            return await _context.Books
                .Where(b => !b.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public Book? FindById(int Id)
        {
            return _context.Books.FirstOrDefault(b => !b.IsDeleted && b.Id == Id);
        }

        public async Task<Book?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Books
                .Include(b => b.Authors)
                .ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.Id == Id, cancellationToken);
        }

        public async Task<bool> IsExists(string Title, CancellationToken cancellationToken)
        {
            return await _context.Books.AnyAsync(b => string.Equals(b.Title, Title), cancellationToken);
        }

        public async Task Update(Book book, CancellationToken cancellationToken)
        {
            book.UpdatedAt = DateTime.Now;
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
