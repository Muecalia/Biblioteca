using Biblioteca.Application.Queries.Request.Author;
using Biblioteca.Application.Queries.Response.Author;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Authors
{
    public class FindAllAuthorHandler : IRequestHandler<FindAllAuthorsRequest, PagedResponse<FindAllAuthorsResponse>>
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public FindAllAuthorHandler(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        public async Task<PagedResponse<FindAllAuthorsResponse>> Handle(FindAllAuthorsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var results = await _iAuthorRepository.GetAllAuthors(cancellationToken);
                var authors = new List<FindAllAuthorsResponse>();

                results.ForEach(result => authors.Add(new FindAllAuthorsResponse {
                    Id = result.Id,
                    Email = result.Email,
                    Name = result.Name,
                    CreatedAt = result.CreatedAt.ToShortDateString()
                }));

                return new PagedResponse<FindAllAuthorsResponse>(authors, "Autores carregados com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ler os autores. Mensagem: {ex}");
                throw;
            }
        }
    }
}
