using Biblioteca.Application.Commands.Request.Users;
using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IUserRepository _iUserRepository;

        public DeleteUserHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _iUserRepository.Find(request.Id, cancellationToken);

                if (customer is null)
                    return ApiResponse<InputUserResponse>.Error("Erro! utilizador não existe");

                await _iUserRepository.Delete(customer, cancellationToken);

                var result = new InputUserResponse
                {
                    Email = customer.Email,
                    Id = customer.Id,
                    Name = customer.Name,
                    Username = customer.UserName,
                    OperationDate = customer.DeletedAt.Value.ToShortDateString()
                };

                return ApiResponse<InputUserResponse>.Success(result, "Sucesso ao eliminar o utilizador");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao eliminar o utilizador. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
