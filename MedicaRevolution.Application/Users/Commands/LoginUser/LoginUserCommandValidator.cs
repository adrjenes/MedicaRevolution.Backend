using FluentValidation;
using RudyGrzebien.Application.Users.Commands.LoginUser;

namespace MedicaRevolution.Application.Users.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(40).WithMessage("Email must not exceed 40 characters.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 20).WithMessage("Password must be between 8 and 20 characters.");
    }
}
