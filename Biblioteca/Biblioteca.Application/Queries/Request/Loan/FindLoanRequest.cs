using Biblioteca.Application.Queries.Response.Loan;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Loan
{
    public class FindLoanRequest : IRequest<ApiResponse<FindLoanResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
