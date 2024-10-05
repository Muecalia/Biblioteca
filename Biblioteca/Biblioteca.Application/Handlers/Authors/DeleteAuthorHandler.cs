using Biblioteca.Application.Commands.Request.Author;
using Biblioteca.Application.Commands.Response.Author;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Authors
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest, ApiResponse<InputAuthorResponse>>
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public DeleteAuthorHandler(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        public async Task<ApiResponse<InputAuthorResponse>> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
			try
			{
                var author = await _iAuthorRepository.GetAuthor(request.Id, cancellationToken);

                if (author is null)
                    return ApiResponse<InputAuthorResponse>.Error("Autor não existe");

                author.DeletedAt = DateTime.Now;
                await _iAuthorRepository.DeleteAuthor(author, cancellationToken);

                var result = new InputAuthorResponse
                {
                    Id = author.Id,
                    Name = author.Name,
                    OperationDate = author.DeletedAt.Value.ToShortDateString()
                };

                return ApiResponse<InputAuthorResponse>.Success(result, "Autor eliminado com sucesso");
            }
			catch (Exception ex)
			{
                System.Diagnostics.Debug.Print($"Erro ao eliminar o autor. ensagem: {ex.Message}");
				throw;
			}
        }
    }
}
