using Biblioteca.Application.Commands.Response.Customer;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Customer
{
    public class UpdateCustomerRequest : IRequest<ApiResponse<InputCustemerResponse>>
    {
        public int Id { get; set; } = 0;
        public string Phone { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
    }
}
