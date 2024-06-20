using FluentValidation;
using RudyGrzebien.Application.Users.Commands.AssignRole;

namespace MedicaRevolution.Application.Users.Commands.AssignRole;

public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommand>
{
    public AssignRoleCommandValidator()
    {
        RuleFor(x => x.Role)
          .NotEmpty().WithMessage("Role is required.")
          .Length(3, 20).WithMessage("Role must be between 3 and 20 characters.");

        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email is required.")
          .EmailAddress().WithMessage("A valid email is required.")
          .MaximumLength(40).WithMessage("Email must not exceed 40 characters.");
        }
}
