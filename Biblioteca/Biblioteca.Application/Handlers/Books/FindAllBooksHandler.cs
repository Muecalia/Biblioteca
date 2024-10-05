using Biblioteca.Application.Queries.Request.Book;
using Biblioteca.Application.Queries.Response.Book;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Books
{
    public class FindAllBooksHandler : IRequestHandler<FindAllBooksRequest, PagedResponse<FindAllBooksResponse>>
    {
        private readonly IBookRepository _iBookRepository;

        public FindAllBooksHandler(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public async Task<PagedResponse<FindAllBooksResponse>> Handle(FindAllBooksRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _iBookRepository.FindAll(cancellationToken);
                var result = new List<FindAllBooksResponse>();

                if (books != null && books.Count > 0)
                    books.ForEach(b => result.Add(new FindAllBooksResponse {
                        Id = b.Id,
                        ISBN = b.ISBN,
                        Title = b.Title,
                        YearPublication = b.YearPublication
                    }));

                return new PagedResponse<FindAllBooksResponse>(result, "Sucesso ao carrgar os livros");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar os livros. Mensagem: {ex}");
                throw;
            }
        }
    }
}
