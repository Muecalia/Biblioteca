using Biblioteca.Application.Queries.Response.Customer;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Customer
{
    public class FindCustomerRequest : IRequest<ApiResponse<FindCustomerResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
