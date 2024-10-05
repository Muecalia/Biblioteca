using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Users
{
    public class UpdateUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
