using Biblioteca.Application.Commands.Request.Book;
using FluentValidation;

namespace Biblioteca.Application.Validators.Books
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookValidator() 
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("O titulo não pode estar vazio")
                .Length(5, 100).WithMessage("O tamanho de caracteres do título deve estar entre 5 e 100");

            RuleFor(b => b.YearPublication)
                .GreaterThanOrEqualTo(2000).WithMessage("O ano de publicação deve ser no mínimo de 2000");
        }
    }
}
