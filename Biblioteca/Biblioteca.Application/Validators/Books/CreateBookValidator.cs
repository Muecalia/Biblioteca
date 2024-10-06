using Biblioteca.Application.Commands.Request.Book;
using FluentValidation;

namespace Biblioteca.Application.Validators.Books
{
    public class CreateBookValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookValidator() 
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("O titulo não pode estar vazio")
                .Length(5, 100).WithMessage("O tamanho de caracteres do título deve estar entre 5 e 100");

            RuleFor(b => b.YearPublication)
                .GreaterThanOrEqualTo(2000).WithMessage("O ano de publicação deve ser no mínimo de 2000");

            RuleFor(b => b.IdAuthors)
                .NotEmpty().WithMessage("Deve ser inserido pelo menos um autor");
        }
    }
}
