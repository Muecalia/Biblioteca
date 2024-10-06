using Biblioteca.Application.Commands.Request.Users;
using FluentValidation;

namespace Biblioteca.Application.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator() 
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O nome não pode estar vazio")
                .Length(2, 100).WithMessage("O tamanho dos caracteres do nome tem de estar entre 2 - 100");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O e-mail não pode estar vazio")
                .EmailAddress().WithMessage("O formato do e-mail não é válido");

            RuleFor(u => u.Phone)
                .NotEmpty().WithMessage("O telefone não pode estar vazio");
        }
    }
}
