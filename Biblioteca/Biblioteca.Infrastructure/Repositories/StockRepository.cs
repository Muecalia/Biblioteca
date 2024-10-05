using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly BibliotecaContext _context;

        public StockRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<Stock> Create(Stock stock, CancellationToken cancellationToken)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync(cancellationToken);
            return stock;
        }

        public async Task Delete(Stock stock, CancellationToken cancellationToken)
        {
            stock.DeletedAt = DateTime.Now;
            stock.IsDeleted = true;
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Stock?> Find(int Id, CancellationToken cancellationToken)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Id == Id, cancellationToken);
        }

        public async Task<List<Stock>> FindAll(CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .Include(s => s.Book)
                .Where(s => !s.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<Stock?> FindByBook(int IdBook, CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .Include(s => s.Book)
                .FirstOrDefaultAsync(s => s.IdBook == IdBook, cancellationToken);
        }

        public async Task<Stock?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .Include(s => s.Book)
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Id, cancellationToken);
        }

        public bool IsBookAvailable(int IdBook)
        {
            return _context.Stocks.Any(s => s.IdBook == IdBook && s.QtdBooks > 0);
        }

        /*
         public async Task<bool> IsBookAvailable(int IdBook, CancellationToken cancellationToken)
        {
            return await _context.Stocks.AnyAsync(s => s.IdBook == IdBook && s.QtdBooks > 0, cancellationToken);
        }
        */

        public async Task Update(Stock stock, CancellationToken cancellationToken)
        {
            stock.UpdatedAt = DateTime.Now;
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
