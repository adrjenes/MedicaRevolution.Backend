using FluentValidation;

namespace MedicaRevolution.Application.Users.Patients.Commands.Register;

public class RegisterPatientCommandValidator : AbstractValidator<RegisterPatientCommand>
{
    public RegisterPatientCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(3, 20).WithMessage("First name must be between 3 and 20 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(3, 30).WithMessage("Last name must be between 3 and 30 characters.");

        RuleFor(x => x.PESEL)
            .NotEmpty().WithMessage("PESEL is required.")
            .Length(11).WithMessage("PESEL must be 11 characters.")
            .Matches(@"^\d{11}$").WithMessage("PESEL must contain only numbers.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(40).WithMessage("Email must not exceed 40 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 20).WithMessage("Password must be between 8 and 20 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Length(9).WithMessage("Phone number must be 9 characters.")
            .Matches(@"^\d{9}$").WithMessage("Phone number must contain only numbers.");
    }
}
