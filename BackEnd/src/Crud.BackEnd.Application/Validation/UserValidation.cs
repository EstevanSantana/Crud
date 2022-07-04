using Crud.BackEnd.Application.Commands;
using FluentValidation;
using System;

namespace Crud.BackEnd.Application.Validation
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand 
    {
        protected void ValidateFistName()
        {
            RuleFor(c => c.FistName)
             .NotEmpty().WithMessage("O nome não foi informado")
             .Length(2, 50).WithMessage("O nome deve ter de {MinLength} a {MaxLength} caracteres");
        }
        
        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("O sobrenome não foi informado")
            .Length(2, 50).WithMessage("O sobrenome deve ter de {MinLength} a {MaxLength} caracteres");
        }

        protected void ValidateBirthday()
        {
            RuleFor(c => c.Birthday)
                .NotEmpty()
                .WithMessage("A data de nascimento não foi informada")
                .LessThan(f => DateTime.Now).WithMessage("A data deve estar no passado.");
        }

        protected void ValidateSchooling()
        {
            RuleFor(c => c.Schooling)
               .NotEmpty().WithMessage("A escolaridade não foi informada");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
             .NotEmpty().WithMessage("O e-mail não foi informado")
             .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id não foi informado");
        }
    }
}
