using Biblioteca.Application.Queries.Request.Loan;
using Biblioteca.Application.Queries.Response.Book;
using Biblioteca.Application.Queries.Response.Loan;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Loans
{
    public class FindLoanHandler : IRequestHandler<FindLoanRequest, ApiResponse<FindLoanResponse>>
    {
        private readonly ILoanRepository _iLoanRepository;

        public FindLoanHandler(ILoanRepository iLoanRepository)
        {
            _iLoanRepository = iLoanRepository;
        }

        public async Task<ApiResponse<FindLoanResponse>> Handle(FindLoanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var loan = await _iLoanRepository.FindDetail(request.Id, cancellationToken);
                if (loan is null) return ApiResponse<FindLoanResponse>.Error("Empréstimo não existe");

                var result = new FindLoanResponse 
                {
                    Id = loan.Id,
                    Comment = loan.Comment,
                    Customer = loan.Customer.Name,
                    Employee = loan.Employee != null ? loan.Employee.Name : string.Empty,
                    Status = loan.Status == Core.Enuns.LoanStatus.Borrowed ? "Emprestado" : "Devolvido",
                    ReturnDate = loan.ReturnDate != null ? loan.ReturnDate.Value.ToShortDateString() : string.Empty,
                    ExpectedReturnDate = loan.ExpectedReturnDate.ToShortDateString(),
                    Books = loan.Books.Select(b => new FindAllBooksResponse { 
                        Id = b.Book.Id,
                        ISBN = b.Book.ISBN,
                        Title = b.Book.Title,
                        YearPublication = b.Book.YearPublication
                    }).ToList()
                };

                return ApiResponse<FindLoanResponse>.Success(result, "Sucesso ao pesquisar o empréstimo");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao pesquisar o empréstimo. Mensagem: {ex}");
                throw;
            }
        }

    }
}
