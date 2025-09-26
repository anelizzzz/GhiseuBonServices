

using FluentValidation;
using GhiseuBon.Dtos;

namespace GhiseuBon.Validators;

public class UserValidator : AbstractValidator<UserDto>
{

    private static readonly string[] AllowedStates = { "admin", "persoanaFizica", "persoanaJuridica" };
    public UserValidator()
    {
        RuleFor(x => x.UserName)
             .NotEmpty().WithMessage("UserName is required.")
             .MaximumLength(100).WithMessage("UserName must not exceed 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

        RuleFor(x => x.RoleUser)
            .NotEmpty().WithMessage("RoleUser is required.")
            .Must(value => AllowedStates.Contains(value?.ToLower()))
            .WithMessage("RoleUser must be one of: admin, persoanaFizica, persoanaJuridica.")
            .MaximumLength(50).WithMessage("RoleUser must not exceed 50 characters.");

        RuleFor(x => x.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt is required.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
    }
}
