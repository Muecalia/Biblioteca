using Biblioteca.Application.Commands.Request.Book;
using Biblioteca.Application.Commands.Response.Book;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, ApiResponse<InputBookResponse>>
    {
        private readonly IBookRepository _iBookRepository;

        public UpdateBookHandler(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public async Task<ApiResponse<InputBookResponse>> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _iBookRepository.Find(request.Id, cancellationToken);

                if (book is null)
                    return ApiResponse<InputBookResponse>.Error("Erro! Livro não existe");

                book.Title = request.Title;
                book.ISBN = request.ISBN;
                book.BarCode = request.BarCode;
                book.Summary = request.Summary;
                book.YearPublication = request.YearPublication;

                await _iBookRepository.Update(book, cancellationToken);

                var result = new InputBookResponse 
                {
                    Id = book.Id,
                    Title = book.Title,
                    YearPublication = book.YearPublication,
                    OperationDate = book.UpdatedAt.Value.ToShortTimeString()                    
                };

                return ApiResponse<InputBookResponse>.Success(result, $"Sucesso ao actualizar os dados do livro {book.Title}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao atualizar os dados do livro. Mensagem: {ex.Message}");
                throw;
            }
        }


    }
}
