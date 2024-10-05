using Biblioteca.Application.Commands.Request.Users;
using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public UpdateUserHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _iUserRepository.Find(request.Id, cancellationToken);

                if (user is null)
                    return ApiResponse<InputUserResponse>.Error("Erro! utilizador não existe");

                DateTime.TryParse(request.DateOfBirth, out DateTime dateOfBirth);

                //if (dateOfBirth == null)
                //    return ApiResponse<InputUserResponse>.Error("Erro! Formato da data de nascimento inválido");

                user.Email = request.Email;
                user.PhoneNumber = request.Phone;
                user.Name = request.Name;
                user.DateOfBirth = dateOfBirth;
                //user.DateOfBirth = (dateOfBirth != null) ? dateOfBirth : null;

                await _iUserRepository.Update(user, cancellationToken);

                var result = new InputUserResponse
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Username = user.UserName,
                    OperationDate = user.UpdatedAt.Value.ToShortDateString()
                };

                return ApiResponse<InputUserResponse>.Success(result, $"Sucesso ao actualizar os dados do utilizador {user.Name}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao atualizar os dados do utilizador. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
