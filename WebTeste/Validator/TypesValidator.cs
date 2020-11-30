using FluentValidation;
using WebTeste.Models;

namespace WebTeste.Validator
{
    public class TypesValidator : AbstractValidator<Types>
    {
        public TypesValidator()
        {

            RuleFor(t => t.Type).NotEmpty().Length(36);

        }
    }
}
