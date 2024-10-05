using Biblioteca.Application.Queries.Response.Users;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Users
{
    public class FindUserRequest : IRequest<ApiResponse<FindUserResponse>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
