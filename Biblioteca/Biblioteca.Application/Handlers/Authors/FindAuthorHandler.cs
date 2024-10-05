using Biblioteca.Application.Queries.Request.Author;
using Biblioteca.Application.Queries.Response.Author;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Authors
{
    public class FindAuthorHandler : IRequestHandler<FindAuthorRequest, ApiResponse<FindAuthorResponse>>
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public FindAuthorHandler(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        public async Task<ApiResponse<FindAuthorResponse>?> Handle(FindAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _iAuthorRepository.GetAuthorById(request.Id, cancellationToken);
                if (author is null)
                    return ApiResponse<FindAuthorResponse>.Error("Autor não existe");

                var result = new FindAuthorResponse 
                {
                    Id = author.Id,
                    Name = author.Name,
                    Email = author.Email,
                    Description = author.Description,
                    CreatedAt = author.CreatedAt.ToShortDateString()
                };

                return ApiResponse<FindAuthorResponse>.Success(result, "Sucesso ao pesquisar o autor");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao pesquisar o autor. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
