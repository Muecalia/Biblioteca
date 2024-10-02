using Biblioteca.Application.Queries.Response.Customer;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Customer
{
    public class FindAllCustomersRequest : IRequest<PagedResponse<FindAllCustomersResponse>>
    {
        public string NameSearch { get; set; } = string.Empty;
    }
}
