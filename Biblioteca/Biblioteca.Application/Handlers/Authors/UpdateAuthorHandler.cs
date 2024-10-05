using Biblioteca.Application.Commands.Request.Author;
using Biblioteca.Application.Commands.Response.Author;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Authors
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest, ApiResponse<InputAuthorResponse>>
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public UpdateAuthorHandler(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        public async Task<ApiResponse<InputAuthorResponse>> Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _iAuthorRepository.GetAuthor(request.Id, cancellationToken);

                if (author is null)
                    return ApiResponse<InputAuthorResponse>.Error("Autor não existe");

                author.Email = request.Email;
                author.Name = request.Name;
                author.Description = request.Description;
                author.UpdatedAt = DateTime.Now;

                await _iAuthorRepository.UpdateAuthor(author, cancellationToken);

                var result = new InputAuthorResponse 
                {
                    Id = author.Id,
                    Name = author.Name,
                    OperationDate = author.UpdatedAt.Value.ToShortDateString(),
                };

                return ApiResponse<InputAuthorResponse>.Success(result, "Autor actualizado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao actualziar o author. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
