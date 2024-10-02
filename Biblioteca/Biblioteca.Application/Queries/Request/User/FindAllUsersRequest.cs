using Biblioteca.Application.Queries.Response.User;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.User
{
    public class FindAllUsersRequest : IRequest<PagedResponse<FindAllUsersResponse>>
    {
        public string NameSearch { get; set; } = string.Empty;
    }
}
