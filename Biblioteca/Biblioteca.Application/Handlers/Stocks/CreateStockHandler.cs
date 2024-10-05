using Biblioteca.Application.Commands.Request.Stocks;
using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Stocks
{
    public class CreateStockHandler : IRequestHandler<CreateStockRequest, ApiResponse<InputStockResponse>>
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IBookRepository _iBookRepository;
        private readonly IStockRepository _iStockRepository;

        public CreateStockHandler(IStockRepository iStockRepository, IBookRepository iBookRepository, IUserRepository iUserRepository)
        {
            _iStockRepository = iStockRepository;
            _iBookRepository = iBookRepository;
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputStockResponse>> Handle(CreateStockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Stock stock;
                var user = await _iUserRepository.Find(request.IdUser, cancellationToken);
                if (user == null) return ApiResponse<InputStockResponse>.Error("Erro! Utiliador não existe");

                var book = await _iBookRepository.Find(request.IdBook, cancellationToken);
                if (book == null) return ApiResponse<InputStockResponse>.Error("Erro! Livro não existe");


                stock = await _iStockRepository.FindByBook(request.IdBook, cancellationToken);
                if (stock != null)
                {
                    stock.QtdBooks += request.QtdBooks;
                    stock.User = user;
                    stock.IdUser = user.Id;
                    await _iStockRepository.Update(stock, cancellationToken);
                }
                else
                {
                    var newStock = new Stock
                    {
                        QtdBooks = request.QtdBooks,
                        IdBook = request.IdBook,
                        User = user,
                        IdUser = user.Id,
                        Book = await _iBookRepository.Find(request.IdBook, cancellationToken)
                    };

                    stock = await _iStockRepository.Create(newStock, cancellationToken);
                }

                var result = new InputStockResponse
                {
                    Id = stock.Id,
                    User = stock.User.Name,
                    Book = stock.Book.Title,
                    QtdBooks = stock.QtdBooks,
                };

                return ApiResponse<InputStockResponse>.Success(result, "Stock criado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao criar o Stock. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
