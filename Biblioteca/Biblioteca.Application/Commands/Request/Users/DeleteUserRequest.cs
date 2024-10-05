using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Users
{
    public class DeleteUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
