using Biblioteca.Application.Queries.Request.Stocks;
using Biblioteca.Application.Queries.Response.Stocks;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Stocks
{
    public class FindStockHandler : IRequestHandler<FindStockRequest, ApiResponse<FindStockResponse>>
    {
        private readonly IStockRepository _iStockRepository;

        public FindStockHandler(IStockRepository iStockRepository)
        {
            _iStockRepository = iStockRepository;
        }

        public async Task<ApiResponse<FindStockResponse>> Handle(FindStockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var stock = await _iStockRepository.FindDetail(request.Id, cancellationToken);
                if (stock is null) return ApiResponse<FindStockResponse>.Error("Erro! stock não existe");

                var result = new FindStockResponse 
                {
                    Id = stock.Id,
                    Book = stock.Book.Title,
                    QtdBooks = stock.QtdBooks,
                    User = stock.User.Name,
                    CreatedAt = stock.CreatedAt.ToShortDateString(),
                    UpdatedAt = stock.UpdatedAt != null ? stock.UpdatedAt.Value.ToShortDateString() : string.Empty,
                };

                return ApiResponse<FindStockResponse>.Success(result, "Sucesso ao pesquisar o stock");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao pesquisar o stock. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
