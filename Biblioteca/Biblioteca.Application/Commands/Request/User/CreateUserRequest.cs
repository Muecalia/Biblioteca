using Biblioteca.Application.Commands.Response.User;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.User
{
    public class CreateUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
