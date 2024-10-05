using Biblioteca.Application.Commands.Request.Author;
using Biblioteca.Application.Commands.Response.Author;
using Biblioteca.Application.Wrappers;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Authors
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorRequest, ApiResponse<InputAuthorResponse>>
    {
        private readonly IAuthorRepository _iAuthorRepository;

        public CreateAuthorHandler(IAuthorRepository iAuthorRepository)
        {
            _iAuthorRepository = iAuthorRepository;
        }

        public async Task<ApiResponse<InputAuthorResponse>> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _iAuthorRepository.IsAuthorExists(request.Name, cancellationToken))
                    return ApiResponse<InputAuthorResponse>.Error("Erro! Autor já cadastrado");

                var newAuthor = new Author 
                {
                    Name = request.Name,
                    Email = request.Email,
                    Description = request.Description                    
                };

                var author = await _iAuthorRepository.CreateAuthor(newAuthor, cancellationToken);

                var result = new InputAuthorResponse 
                {
                    Id = author.Id,
                    Name = author.Name,
                    OperationDate = author.CreatedAt.ToShortDateString()
                };

                return ApiResponse<InputAuthorResponse>.Success(result, "Autor Criado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao criar o autor. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
