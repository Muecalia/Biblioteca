using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> Create(Stock stock, CancellationToken cancellationToken);
        Task Update(Stock stock, CancellationToken cancellationToken);
        Task Delete(Stock stock, CancellationToken cancellationToken);
        Task<List<Stock>> FindAll(CancellationToken cancellationToken);
        Task<Stock> Find(int Id, CancellationToken cancellationToken);
        //Stock Find(int Id);
        Task<Stock> FindByBook(int IdBook, CancellationToken cancellationToken);
        Task<Stock> FindDetail(int Id, CancellationToken cancellationToken);
        //Task<bool> IsBookAvailable(int IdBook, CancellationToken cancellationToken);
        bool IsBookAvailable(int IdBook);
    }
}
