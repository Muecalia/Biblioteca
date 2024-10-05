using Biblioteca.Application.Commands.Response.Users;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Users
{
    public class ChangePasswordUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public string Id { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
