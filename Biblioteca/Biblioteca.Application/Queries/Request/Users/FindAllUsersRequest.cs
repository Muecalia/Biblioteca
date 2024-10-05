using Biblioteca.Application.Queries.Response.Users;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Users
{
    public class FindAllUsersRequest : IRequest<PagedResponse<FindAllUsersResponse>>
    {
        public string NameSearch { get; set; } = string.Empty;
    }
}
