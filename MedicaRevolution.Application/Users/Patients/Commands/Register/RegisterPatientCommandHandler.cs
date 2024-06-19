using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MedicaRevolution.Application.Users.Patients.Commands.Register;

public class RegisterPatientCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<RegisterPatientCommand, RegisterPatientResult>
{
    public async Task<RegisterPatientResult> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PESEL = request.PESEL,
            UserName = request.Email,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var roleResult = await userManager.AddToRoleAsync(user, "Patient");
            if (!roleResult.Succeeded)
            {
                return new RegisterPatientResult { Success = false, Errors = roleResult.Errors.Select(e => e.Description) };
            }
            return new RegisterPatientResult { Success = true };
        }

        return new RegisterPatientResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
    }
}