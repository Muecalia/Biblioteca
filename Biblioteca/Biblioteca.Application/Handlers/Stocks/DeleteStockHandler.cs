using Biblioteca.Application.Commands.Request.Stocks;
using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Stocks
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockRequest, ApiResponse<InputStockResponse>>
    {
        private readonly IStockRepository _iStockRepository;
        private readonly ILoanBooksRepository _iLoanBooksRepository;

        public DeleteStockHandler(IStockRepository iStockRepository, ILoanBooksRepository iLoanBooksRepository)
        {
            _iStockRepository = iStockRepository;
            _iLoanBooksRepository = iLoanBooksRepository;
        }

        public async Task<ApiResponse<InputStockResponse>> Handle(DeleteStockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var stock = await _iStockRepository.Find(request.Id, cancellationToken);
                if (stock == null) return ApiResponse<InputStockResponse>.Error("Erro! stock não existe");

                if (await _iLoanBooksRepository.IsBookLoan(stock.IdBook, cancellationToken))
                    return ApiResponse<InputStockResponse>.Error("Não é possível eliminar o stock, porque o livro já e encontra em uso");

                await _iStockRepository.Delete(stock, cancellationToken);

                var result = new InputStockResponse
                {
                    Id = stock.Id,
                    User = stock.User.Name,
                    Book = stock.Book.Title,
                    QtdBooks = stock.QtdBooks,
                };

                return ApiResponse<InputStockResponse>.Success(result, "Stock eliminado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao eliminar o Stock. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
