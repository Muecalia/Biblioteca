using Biblioteca.Application.Queries.Request.Stocks;
using Biblioteca.Application.Queries.Response.Stocks;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Stocks
{
    public class FindAllStocksHandler : IRequestHandler<FindAllStocksRequest, PagedResponse<FindAllStocksResponse>>
    {
        private readonly IStockRepository _iStockRepository;

        public FindAllStocksHandler(IStockRepository iStockRepository)
        {
            _iStockRepository = iStockRepository;
        }

        public async Task<PagedResponse<FindAllStocksResponse>> Handle(FindAllStocksRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<FindAllStocksResponse>();
                var stocks = await _iStockRepository.FindAll(cancellationToken);

                stocks.ForEach(stock => result.Add(new FindAllStocksResponse {
                    Id = stock.Id,
                    Book = stock.Book.Title,
                    CreatedAt = stock.CreatedAt.ToShortDateString(),
                    QtdBooks = stock.QtdBooks,
                    User = stock.User.Name,
                    UpdatedAt = stock.UpdatedAt != null ? stock.UpdatedAt.Value.ToShortDateString() : string.Empty,
                }));

                return new PagedResponse<FindAllStocksResponse>(result, "stocks carregados com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ler os stocks. Mensagem: {ex}");
                throw;
            }
        }

    }
}
