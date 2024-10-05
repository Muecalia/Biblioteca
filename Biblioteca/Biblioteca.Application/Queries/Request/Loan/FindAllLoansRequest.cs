using Biblioteca.Application.Queries.Response.Loan;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Loan
{
    public class FindAllLoansRequest : IRequest<PagedResponse<FindAllLoansResponse>>
    {
        public string Customer { get; set; } = string.Empty;
    }
}
