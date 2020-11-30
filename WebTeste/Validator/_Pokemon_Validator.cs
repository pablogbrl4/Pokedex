using FluentValidation;
using WebTeste.Models;

namespace WebTeste.Validator
{
    public class _Pokemon_Validator : AbstractValidator<_Pokemon_>
    {
        public _Pokemon_Validator()
        {

            RuleFor(t => t.Pokedex_Index).NotEmpty().ExclusiveBetween(1, 50);

            RuleFor(t => t.Name).NotEmpty().Length(1,26);

            RuleFor(t => t.Hp).NotEmpty().ExclusiveBetween(1, 255);

            RuleFor(t => t.Attack).NotEmpty().ExclusiveBetween(5, 190);

            RuleFor(t => t.Defense).NotEmpty().ExclusiveBetween(5, 230);

            RuleFor(t => t.Special_attack).NotEmpty().ExclusiveBetween(10, 194);

            RuleFor(t => t.Special_defense).NotEmpty().ExclusiveBetween(20, 230);

            RuleFor(t => t.Speed).NotEmpty().ExclusiveBetween(5, 180);

            RuleFor(t => t.Generation).NotEmpty().ExclusiveBetween(1, 6);

        }
    }
}
