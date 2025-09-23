using FluentValidation;
using GhiseuBon.Dtos;

namespace GhiseuBon.Validators;

public class BonValidator : AbstractValidator<BonDto>
{
    private static readonly string[] AllowedStates = { "in procress", "preluat", "inchis" }; //Adaugare enum class
    public BonValidator()
    {

        RuleFor(x => x.IdGhiseu)
            .GreaterThan(0).WithMessage("IdGhiseu must be greater than 0.");

        RuleFor(x => x.Stare)
            .NotEmpty().WithMessage("Stare is required.")
            .Must(value => AllowedStates.Contains(value?.ToLower()))
            .WithMessage("Stare must be one of: in progress, received, closed.")
            .MaximumLength(50);

        RuleFor(x => x.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt is required.");

        RuleFor(x => x.ModifiedAt)
            .NotEmpty().WithMessage("ModifiedAt is required.")
            .GreaterThanOrEqualTo(x => x.CreatedAt)
            .WithMessage("ModifiedAt must be after or equal to CreatedAt.");


    }
}
