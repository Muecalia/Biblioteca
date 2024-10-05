using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LoanBooksRepository : ILoanBooksRepository
    {
        private readonly BibliotecaContext _context;

        public LoanBooksRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task Create(List<LoanBooks> loanbooks, CancellationToken cancellationToken)
        {
            _context.LoanBooks.AddRange(loanbooks);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(LoanBooks loanbook, CancellationToken cancellationToken)
        {
            loanbook.DeletedAt = DateTime.Now;
            loanbook.IsDeleted = true;
            _context.LoanBooks.Update(loanbook);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<LoanBooks?> Find(int Id, CancellationToken cancellationToken)
        {
            return await _context.LoanBooks.IgnoreAutoIncludes().FirstOrDefaultAsync(lb => !lb.IsDeleted && lb.Id == Id, cancellationToken);
        }

        public async Task<bool> IsBookLoan(int IdBook, CancellationToken cancellationToken)
        {
            return await _context.LoanBooks.AnyAsync(lb => !lb.IsDeleted && lb.IdBook == IdBook, cancellationToken);
        }

        public async Task<LoanBooks?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.LoanBooks
                .Include(lb => lb.Loan)
                .Include(lb => lb.Book)
                .FirstOrDefaultAsync(lb => lb.Id == Id, cancellationToken);
        }

        public async Task Update(LoanBooks loanbook, CancellationToken cancellationToken)
        {
            loanbook.UpdatedAt = DateTime.Now;
            _context.LoanBooks.Update(loanbook);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
