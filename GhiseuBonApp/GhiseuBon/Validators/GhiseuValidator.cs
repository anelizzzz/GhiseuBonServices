using FluentValidation;
using GhiseuBon.Dtos;

namespace GhiseuBon.Validators;

public class GhiseuValidator : AbstractValidator<GhiseuDto>
{
    public GhiseuValidator()
    {

        RuleFor(x => x.Cod)
                    .NotEmpty().WithMessage("Cod is required.")
                    .MaximumLength(10);

        RuleFor(x => x.Denumire)
            .NotEmpty().WithMessage("Denumire is required.")
            .MaximumLength(50);

        RuleFor(x => x.Descriere)
            .MaximumLength(50);

        RuleFor(x => x.Icon)
            .MaximumLength(10);

        RuleFor(x => x.Activ)
            .NotNull().WithMessage("Activ must be specified.");

    }
}
