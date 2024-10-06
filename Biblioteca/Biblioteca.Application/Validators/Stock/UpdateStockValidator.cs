using Biblioteca.Application.Commands.Request.Stocks;
using FluentValidation;

namespace Biblioteca.Application.Validators.Stock
{
    public class UpdateStockValidator : AbstractValidator<UpdateStockRequest>
    {
        public UpdateStockValidator() 
        {
            RuleFor(s => s.QtdBooks)
                .GreaterThanOrEqualTo(1).WithMessage("A quantidade de livros deve ser maior que zero (0)");

            RuleFor(s => s.Id)
                .GreaterThanOrEqualTo(1).WithMessage("O código do stock deve ser maior que zero (0)");

            RuleFor(s => s.IdUser)
                .NotEmpty().WithMessage("O código do utilizador não pode estar vazio")
                .Length(36).WithMessage("O código inserido não cumpre com o formato");
        }
    }
}
