using Biblioteca.Application.Commands.Request.Stocks;
using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Stocks
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockRequest, ApiResponse<InputStockResponse>>
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IStockRepository _iStockRepository;

        public UpdateStockHandler(IStockRepository iStockRepository, IUserRepository iUserRepository)
        {
            _iStockRepository = iStockRepository;
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputStockResponse>> Handle(UpdateStockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _iUserRepository.Find(request.IdUser, cancellationToken);
                if (user == null) return ApiResponse<InputStockResponse>.Error("Erro! Utiliador não existe");

                var stock = await _iStockRepository.Find(request.Id, cancellationToken);
                if (stock == null) return ApiResponse<InputStockResponse>.Error("Erro! stock não existe");

                stock.QtdBooks += request.QtdBooks;
                stock.User = user;
                stock.IdUser = user.Id;
                await _iStockRepository.Update(stock, cancellationToken);

                var result = new InputStockResponse
                {
                    Id = stock.Id,
                    User = stock.User.Name,
                    Book = stock.Book.Title,
                    QtdBooks = stock.QtdBooks,
                };

                return ApiResponse<InputStockResponse>.Success(result, "Stock actualizado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao atualizar o Stock. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
