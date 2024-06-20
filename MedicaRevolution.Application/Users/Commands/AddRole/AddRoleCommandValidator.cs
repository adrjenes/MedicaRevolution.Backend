using FluentValidation;
using RudyGrzebien.Application.Users.Commands.AddRole;

namespace MedicaRevolution.Application.Users.Commands.AddRole;
public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required.")
            .Length(3, 20).WithMessage("Role must be between 3 and 20 characters.");
    }
}