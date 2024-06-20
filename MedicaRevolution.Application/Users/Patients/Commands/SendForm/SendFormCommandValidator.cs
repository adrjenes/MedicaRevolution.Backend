using FluentValidation;
using MedicaRevolution.Application.Users.Patients.Commands.Register;

namespace MedicaRevolution.Application.Users.Patients.Commands.SendForm;

public class SendFormCommandValidator : AbstractValidator<SendFormCommand>
{
    public SendFormCommandValidator()
    {
        RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Description is required.")
               .Length(200, 1000).WithMessage("Description must be between 200 and 1000 characters.");
    }
}
