using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> Create(Loan loan, CancellationToken cancellationToken);
        Task Update(Loan loan, CancellationToken cancellationToken);
        Task Delete(Loan loan, CancellationToken cancellationToken);
        Task<Loan> Find(int Id, CancellationToken cancellationToken);
        Task<List<Loan>> FindAll(CancellationToken cancellationToken);
        Task<Loan> FindDetail(int Id, CancellationToken cancellationToken);
        Task<bool> IsBorrowed(int Id, CancellationToken cancellationToken);
    }
}
