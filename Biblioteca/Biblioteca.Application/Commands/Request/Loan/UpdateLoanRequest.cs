using Biblioteca.Application.Commands.Response.Loan;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Loan
{
    public class UpdateLoanRequest : IRequest<ApiResponse<UpdateLoanResponse>>
    {
        public int Id { get; set; } = 0;
        public string IdEmployee { get; set; } = string.Empty;
        //public int Status { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
    }
}
