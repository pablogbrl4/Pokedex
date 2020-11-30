using FluentValidation;
using WebTeste.Models;

namespace WebTeste.Validator
{
    public class Pokemon_TypesValidator : AbstractValidator<Pokemon_Types>
    {
        public Pokemon_TypesValidator()
        {
            RuleFor(t => t.Pokemon_Id).NotEmpty().Length(36);

            RuleFor(t => t.Type_Id).NotEmpty().Length(36);

        }
    }
}
