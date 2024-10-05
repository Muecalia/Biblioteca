using Biblioteca.Application.Commands.Request.Book;
using Biblioteca.Application.Commands.Response.Book;
using Biblioteca.Application.Wrappers;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Books
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, ApiResponse<InputBookResponse>>
    {
        private readonly IBookRepository _iBookRepository;
        private readonly IAuthorRepository _iAuthorRepository;
        private readonly IAuthorBooksRepository _iAuthorBooksRepository;

        public CreateBookHandler(IBookRepository iBookRepository, IAuthorRepository iAuthorRepository, IAuthorBooksRepository iAuthorBooksRepository)
        {
            _iBookRepository = iBookRepository;
            _iAuthorRepository = iAuthorRepository;
            _iAuthorBooksRepository = iAuthorBooksRepository;
        }

        public async Task<ApiResponse<InputBookResponse>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _iBookRepository.IsExists(request.Title, cancellationToken))
                    return ApiResponse<InputBookResponse>.Error("Erro! Já existe um livro com este título");

                if (request.IdAuthors.Count <= 0)
                    return ApiResponse<InputBookResponse>.Error("Erro! Deve inserir pelo menos um autor");

                Console.WriteLine(request.IdAuthors.Count);

                var autores = new List<AuthorBooks>();

                request.IdAuthors.ForEach(IdAuthor => {
                    var author = _iAuthorRepository.FindAuthor(IdAuthor);
                    if (author != null)
                    {
                        autores.Add(new AuthorBooks
                        {
                            Author = author,
                            IdAuthor = author.Id
                        });
                    }                    
                });

                if (autores.Count <= 0)
                    return ApiResponse<InputBookResponse>.Error("Erro! O(s) autor(es) inserido(s) não existe(m)");

                var newBook = new Book
                {
                    Title = request.Title,
                    BarCode = request.BarCode,
                    ISBN = request.ISBN,
                    Summary = request.Summary,
                    YearPublication = request.YearPublication,
                    Authors = autores
                };

                var book = await _iBookRepository.Create(newBook, cancellationToken);

                if (book is null)
                    return ApiResponse<InputBookResponse>.Error("Erro ao salvar o livro");

                var result = new InputBookResponse 
                {
                    Id = book.Id,
                    Title = book.Title,
                    OperationDate = book.CreatedAt.ToShortDateString(),
                    YearPublication = book.YearPublication
                };

                return ApiResponse<InputBookResponse>.Success(result, "Livro criado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao criar o livro. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
