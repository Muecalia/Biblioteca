using Biblioteca.Application.Commands.Request.Users;
using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public CreateUserHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _iUserRepository.IsExists(request.Name, cancellationToken))
                    return ApiResponse<InputUserResponse>.Error("Erro! Já existe um cliente com este nome");

                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    UserName = request.Email,
                    Profile = request.Profile,
                    PhoneNumber = request.Phone
                };

                var user = await _iUserRepository.Create(newUser, request.Password, request.Profile, cancellationToken);

                if (user == null)
                    return ApiResponse<InputUserResponse>.Error("Erro o criar a conta do utilizador");

                var result = new InputUserResponse
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Username = user.UserName,
                    OperationDate = user.CreatedAt.ToShortDateString()
                };

                return ApiResponse<InputUserResponse>.Success(result, "Cliente criado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o cliente. Mensagem: {ex.Message}");
                return ApiResponse<InputUserResponse>.Error($"Erro ao criar o cliente. Mensagem: {ex.Message}");
                //throw;
            }
        }
    }
}
