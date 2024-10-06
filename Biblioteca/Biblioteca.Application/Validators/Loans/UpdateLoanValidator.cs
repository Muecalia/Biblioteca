using Biblioteca.Application.Commands.Request.Loan;
using FluentValidation;

namespace Biblioteca.Application.Validators.Loans
{
    public class UpdateLoanValidator : AbstractValidator<UpdateLoanRequest>
    {
        public UpdateLoanValidator() 
        {
            RuleFor(l => l.Id)
                .GreaterThanOrEqualTo(1).WithMessage("O código do empréstimo deve ser maior que zero (0)");

            RuleFor(l => l.IdEmployee)
                .NotEmpty().WithMessage("O Id do utilizador não pode estar vazio")
                .Length(36).WithMessage("O tamanho de caracteres deve ser 36");
        }
    }
}
