using Biblioteca.Application.Commands.Request.Book;
using Biblioteca.Application.Commands.Response.Book;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, ApiResponse<InputBookResponse>>
    {
        private readonly IBookRepository _iBookRepository;

        public DeleteBookHandler(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public async Task<ApiResponse<InputBookResponse>> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _iBookRepository.Find(request.Id, cancellationToken);
                
                if (book is null)
                    return ApiResponse<InputBookResponse>.Error("Erro! Livro não existe");

                await _iBookRepository.Delete(book, cancellationToken);

                var result = new InputBookResponse 
                {
                    Id = book.Id,
                    Title = book.Title,
                    OperationDate = book.DeletedAt.Value.ToShortDateString(),
                    YearPublication = book.YearPublication
                };

                return ApiResponse<InputBookResponse>.Success(result, "Sucesso ao eliminar o livro");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao eliminar o livro. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
