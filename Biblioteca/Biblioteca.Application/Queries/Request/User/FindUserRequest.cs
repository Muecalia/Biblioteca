using Biblioteca.Application.Queries.Response.User;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.User
{
    public class FindUserRequest : IRequest<ApiResponse<FindUserResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
