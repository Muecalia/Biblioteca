using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface ILoanBooksRepository
    {
        Task Create(List<LoanBooks> loanbooks, CancellationToken cancellationToken);
        Task Update(LoanBooks loanbook, CancellationToken cancellationToken);
        Task Delete(LoanBooks loanbook, CancellationToken cancellationToken);
        Task<LoanBooks> Find(int Id, CancellationToken cancellationToken);
        Task<bool> IsBookLoan(int IdBook, CancellationToken cancellationToken);
        Task<LoanBooks> FindDetail(int Id, CancellationToken cancellationToken);
        
    }
}
