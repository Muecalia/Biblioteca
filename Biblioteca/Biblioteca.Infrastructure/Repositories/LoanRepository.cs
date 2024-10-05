using Biblioteca.Core.Entities;
using Biblioteca.Core.Enuns;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BibliotecaContext _context;

        public LoanRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<Loan> Create(Loan loan, CancellationToken cancellationToken)
        {
            _context.Loans.Add(loan);
            var stock = new List<Stock>();

            loan.Books.ForEach(b => {
                var item = _context.Stocks.FirstOrDefault(s => s.IdBook == b.IdBook);
                if (item != null)
                {
                    item.QtdBooks -= 1;
                    stock.Add(item);
                }                
            });

            if (stock.Count <= 0)
                return null;

            _context.Stocks.UpdateRange(stock);
            await _context.SaveChangesAsync(cancellationToken);

            return loan;
        }

        public async Task Delete(Loan loan, CancellationToken cancellationToken)
        {
            loan.IsDeleted = true;
            loan.DeletedAt = DateTime.Now;
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Loan?> Find(int Id, CancellationToken cancellationToken)
        {
            return await _context.Loans.Include(l => l.Books).FirstOrDefaultAsync(l => !l.IsDeleted && l.Id == Id, cancellationToken);
        }

        public async Task<List<Loan>> FindAll(CancellationToken cancellationToken)
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Include(l => l.Books)
                .ThenInclude(b => b.Book)
                .Where(l => !l.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<Loan?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Include(l => l.Books)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(l => !l.IsDeleted && l.Id == Id, cancellationToken);
        }

        public async Task<bool> IsBorrowed(int Id, CancellationToken cancellationToken)
        {
            return await _context.Loans
                .IgnoreAutoIncludes()
                .AnyAsync(l => l.Id == Id && l.Status == LoanStatus.Borrowed, cancellationToken);
        }

        public async Task Update(Loan loan, CancellationToken cancellationToken)
        {
            var stock = new List<Stock>();

            loan.Books.ForEach(b => {
                var item = _context.Stocks.FirstOrDefault(s => s.IdBook == b.IdBook);
                item.QtdBooks += 1;
                stock.Add(item);
                System.Diagnostics.Debug.WriteLine($"IdBook: {b.IdBook} - stock: {item.IdBook}");
            });

            loan.Status = LoanStatus.Returned;
            loan.UpdatedAt = DateTime.Now;
            _context.Loans.Update(loan);
            _context.Stocks.UpdateRange(stock);
            await _context.SaveChangesAsync();
        }
    }
}
