using Biblioteca.Application.Commands.Response.Loan;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Loan
{
    public class CreateLoanRequest : IRequest<ApiResponse<InputLoanResponse>>
    {
        public int IdCustomer { get; set; } = 0;
        public List<int> IdBooks { get; set; } = [];
        public string ExpectedReturnDate { get; set; } = string.Empty;
    }
}
