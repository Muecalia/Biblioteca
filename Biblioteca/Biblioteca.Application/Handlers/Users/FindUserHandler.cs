using Biblioteca.Application.Queries.Request.Users;
using Biblioteca.Application.Queries.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class FindUserHandler : IRequestHandler<FindUserRequest, ApiResponse<FindUserResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public FindUserHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<FindUserResponse>> Handle(FindUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _iUserRepository.FindDetail(request.Id, cancellationToken);

                if (user == null) return ApiResponse<FindUserResponse>.Error("Erro! utilizador não existe");

                var result = new FindUserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.UserName,
                    Phone = user.PhoneNumber,
                    CreatedAt = user.CreatedAt.ToShortDateString(),
                    UpdatedAt = user.UpdatedAt != null ? user.UpdatedAt.Value.ToShortDateString() : string.Empty,
                    DateOfBirth = user.DateOfBirth != null ? user.DateOfBirth.Value.ToShortDateString() : string.Empty
                };

                return ApiResponse<FindUserResponse>.Success(result, "Sucesso ao pesquisar o utilizador");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao pesquisar o utilizador. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
