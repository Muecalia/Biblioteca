using Biblioteca.Application.Commands.Request.Loan;
using Biblioteca.Application.Commands.Request.Notification;
using Biblioteca.Application.Commands.Response.Loan;
using Biblioteca.Application.Wrappers;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Loans
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanRequest, ApiResponse<UpdateLoanResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _iBookRepository;
        private readonly ILoanRepository _iLoanRepository;
        private readonly IStockRepository _iStockRepository;
        private readonly IUserRepository _iUserRepository;

        public UpdateLoanHandler(ILoanRepository iLoanRepository, IStockRepository iStockRepository, IBookRepository iBookRepository, IUserRepository iUserRepository, IMediator mediator)
        {
            _iLoanRepository = iLoanRepository;
            _iStockRepository = iStockRepository;
            _iBookRepository = iBookRepository;
            _iUserRepository = iUserRepository;
            _mediator = mediator;
        }

        public async Task<ApiResponse<UpdateLoanResponse>> Handle(UpdateLoanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var loan = await _iLoanRepository.Find(request.Id, cancellationToken);
                if (loan is null) return ApiResponse<UpdateLoanResponse>.Error("Empréstimo não existe");

                if (loan.Status == Core.Enuns.LoanStatus.Returned) return ApiResponse<UpdateLoanResponse>.Error("Empréstimo já fechado");

                var employee = await _iUserRepository.Find(request.IdEmployee, cancellationToken);
                if (employee is null) return ApiResponse<UpdateLoanResponse>.Error("Utilizador não existe");

                loan.ReturnDate = DateTime.Now;
                loan.UpdatedAt = DateTime.Now;
                loan.IdEmployee = request.IdEmployee;
                loan.Employee = employee;
                loan.Comment = request.Comment;

                await _iLoanRepository.Update(loan, cancellationToken);

                if (loan.ReturnDate > loan.ExpectedReturnDate)
                {
                    var notification = new CreateLoanNotificationRequest 
                    {
                        //ReturnDate = loan.ReturnDate.Value,
                        Message = $"Devolução do(s) livro(s), realizado fora do prazo definido ({loan.ExpectedReturnDate.ToShortDateString()})"
                    };
                    await _mediator.Publish(notification, cancellationToken);
                }

                var result = new UpdateLoanResponse 
                {
                    Comment = request.Comment,
                    Id = loan.Id,
                    QtdBooks = loan.Books.Count,
                    Employee = employee.Name,
                    ReturnDate = loan.ReturnDate.Value.ToShortDateString()
                };

                return ApiResponse<UpdateLoanResponse>.Success(result, "Emprestimo de livro(s) realizado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao registar a devolução dos livos. Mensagem: {ex.Message}");
                throw;
            }
        }

    }
}
