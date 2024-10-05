using Biblioteca.Application.Queries.Request.Book;
using Biblioteca.Application.Queries.Response.Book;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Books
{
    public class FindBookHandler : IRequestHandler<FindBookRequest, ApiResponse<FindBookResponse>>
    {
        private readonly IBookRepository _iBookRepository;

        public FindBookHandler(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public async Task<ApiResponse<FindBookResponse>> Handle(FindBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _iBookRepository.FindDetail(request.Id, cancellationToken);
                if (book == null)
                    return ApiResponse<FindBookResponse>.Error("Erro! Livro não existe");

                var result = new FindBookResponse 
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    BarCode = book.BarCode,
                    Title = book.Title,
                    Summary = book.Summary,
                    YearPublication = book.YearPublication,
                    Authors = book.Authors.Select(x => x.Author.Name).ToList()
                };

                return ApiResponse<FindBookResponse>.Success(result, "Sucesso ao pesquisar o livro");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao pesquisar o livro. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
