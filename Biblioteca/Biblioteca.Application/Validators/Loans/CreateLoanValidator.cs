using Biblioteca.Application.Commands.Request.Loan;
using FluentValidation;

namespace Biblioteca.Application.Validators.Loans
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanRequest>
    {
        public CreateLoanValidator() 
        {
            RuleFor(l => l.IdUser)
                .NotEmpty().WithMessage("O Id do utilizador não pode estar vazio")
                .Length(36).WithMessage("O tamanho de caracteres deve ser 36");

            RuleFor(l => l.IdBooks)
                .NotEmpty().WithMessage("Deve inserir pelo menos um libro");

            RuleFor(l => l.ExpectedReturnDate)
                .NotEmpty().WithMessage("Deve inserir a data de devolução do(s) livro(s)")
                .Must(d => DateTime.Parse(d)  > DateTime.Now).WithMessage("A data de devolução tem que ser maior que a data actual");
        }
    }
}
