using Biblioteca.Application.Commands.Request.Loan;
using Biblioteca.Application.Commands.Response.Loan;
using Biblioteca.Application.Wrappers;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;
using System.Text;

namespace Biblioteca.Application.Handlers.Loans
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanRequest, ApiResponse<InputLoanResponse>>
    {
        private readonly IBookRepository _iBookRepository;
        private readonly ILoanRepository _iLoanRepository;
        private readonly IStockRepository _iStockRepository;
        private readonly IUserRepository _iUserRepository;

        public CreateLoanHandler(ILoanRepository iLoanRepository, IStockRepository iStockRepository, IBookRepository iBookRepository, IUserRepository iUserRepository)
        {
            _iLoanRepository = iLoanRepository;
            _iStockRepository = iStockRepository;
            _iBookRepository = iBookRepository;
            _iUserRepository = iUserRepository;
        }

        public async Task<ApiResponse<InputLoanResponse>> Handle(CreateLoanRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var books = new List<LoanBooks>();
                var sb = new StringBuilder();
                //Book book;
                var user = await _iUserRepository.Find(request.IdUser, cancellationToken);
                if (user is null)
                    return ApiResponse<InputLoanResponse>.Error("Erro! Utilizador não existe");

                DateTime.TryParse(request.ExpectedReturnDate, out DateTime expectedReturnDate);

                if (expectedReturnDate == null)
                    return ApiResponse<InputLoanResponse>.Error("Erro! Formato da data de devolução inválido");

                request.IdBooks.ForEach(IdBook => {
                    System.Diagnostics.Debug.WriteLine($"IdBook: {IdBook}");
                    if (_iStockRepository.IsBookAvailable(IdBook))
                    {
                        var book = _iBookRepository.FindById(IdBook);
                        books.Add(new LoanBooks { Book = book, IdBook = book.Id });
                    }
                });

                if (books.Count <= 0)
                    return ApiResponse<InputLoanResponse>.Error("Os livros selecionados não estão disponíveis neste momento");

                var newLoan = new Loan 
                {
                    IdCustomer = request.IdUser,
                    Customer = user,
                    Books = books,
                    ExpectedReturnDate = expectedReturnDate                    
                };

                var loan = await _iLoanRepository.Create(newLoan, cancellationToken);

                if (loan is null)
                    return ApiResponse<InputLoanResponse>.Error("Erro! O livro ainda não está disponível para empréstimos");

                var result = new InputLoanResponse
                {
                    Id = loan.Id,
                    Customer = user.Name,
                    QtdBooks = books.Count,
                    ExpectedReturnDate = loan.ExpectedReturnDate.ToShortDateString()
                };

                return ApiResponse<InputLoanResponse>.Success(result, "Emprestimo de livro(s) realizado com sucesso");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao registar o empréstimo dos livos. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
