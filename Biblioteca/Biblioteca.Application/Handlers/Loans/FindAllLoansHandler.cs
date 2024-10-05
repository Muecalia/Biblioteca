using Biblioteca.Application.Queries.Request.Loan;
using Biblioteca.Application.Queries.Response.Loan;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Loans
{
    public class FindAllLoansHandler : IRequestHandler<FindAllLoansRequest, PagedResponse<FindAllLoansResponse>>
    {
        private readonly ILoanRepository _iLoanRepository;

        public FindAllLoansHandler(ILoanRepository iLoanRepository)
        {
            _iLoanRepository = iLoanRepository;
        }

        public async Task<PagedResponse<FindAllLoansResponse>> Handle(FindAllLoansRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var loans = await _iLoanRepository.FindAll(cancellationToken);
                var result = new List<FindAllLoansResponse>();

                loans.ForEach(l => result.Add(new FindAllLoansResponse {                    
                    Id = l.Id,
                    User = l.Employee != null ? l.Employee.Name : string.Empty,
                    Customer = l.Customer.Name,
                    Status = l.Status == Core.Enuns.LoanStatus.Borrowed ? "Emprestado" : "Devolvido",
                    ReturnDate = l.ReturnDate != null ? l.ReturnDate.Value.ToShortDateString() : string.Empty,
                    ExpectedReturnDate = l.ExpectedReturnDate.ToShortDateString()
                }));

                return new PagedResponse<FindAllLoansResponse>(result, "Sucesso ao carrgar os empréstimos");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar os empréstimos. Mensagem: {ex}");
                throw;
            }
        }

    }
}
