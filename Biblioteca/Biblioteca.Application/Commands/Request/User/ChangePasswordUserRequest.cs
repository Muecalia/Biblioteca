using Biblioteca.Application.Commands.Response.User;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.User
{
    public class ChangePasswordUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public int Id { get; set; } = 0;
        public string NewPassword { get; set; } = string.Empty;
    }
}
