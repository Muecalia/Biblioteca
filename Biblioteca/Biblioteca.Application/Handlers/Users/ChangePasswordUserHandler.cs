using Biblioteca.Application.Commands.Request.Users;
using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class ChangePasswordUserHandler : IRequestHandler<ChangePasswordUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public ChangePasswordUserHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(ChangePasswordUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _iUserRepository.Find(request.Id, cancellationToken);

                if (user is null) return ApiResponse<InputUserResponse>.Error("Erro! Cliente não existe");

                await _iUserRepository.ChangePassword(user, request.OldPassword, request.NewPassword, cancellationToken);

                var result = new InputUserResponse
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    OperationDate = user.UpdatedAt.Value.ToShortDateString()
                };

                return ApiResponse<InputUserResponse>.Success(result, $"Password do cliente {user.Name} actualizada com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao atualizar a password do cliente. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
