using Biblioteca.Application.Commands.Request.Author;
using FluentValidation;

namespace Biblioteca.Application.Validators.Autores
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorValidator() 
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Nome do autor não pode ser vazio")
                .Length(2, 100).WithMessage("O tamanho de caracteres do nome deve estar entre 2 e 100");

            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("O formato do email não está correcto");
        }
    }
}
