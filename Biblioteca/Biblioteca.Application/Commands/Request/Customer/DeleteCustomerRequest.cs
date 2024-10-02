using Biblioteca.Application.Commands.Response.Customer;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Customer
{
    public class DeleteCustomerRequest : IRequest<ApiResponse<InputCustemerResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
