using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Application.Users.Patients.Commands.Register;

public class RegisterPatientCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, TokenService tokenService) : IRequestHandler<RegisterPatientCommand, RegisterPatientResult>
{
    public async Task<RegisterPatientResult> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        var existingUserByEmail = await userManager.FindByEmailAsync(request.Email);
        var existingUserByPesel = await userManager.Users.FirstOrDefaultAsync(u => u.PESEL == request.PESEL);
        var existingUserByPhoneNumber = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);

        if (existingUserByEmail != null || existingUserByPesel != null || existingUserByPhoneNumber != null) return new RegisterPatientResult { Success = false, Errors = new[] { "Something went wrong." } };
       
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
            if (!roleResult.Succeeded) return new RegisterPatientResult { Success = false, Errors = roleResult.Errors.Select(e => e.Description) };
            var token = await tokenService.GenerateToken(user);
            return new RegisterPatientResult { Success = true, Token = token };
        }

        return new RegisterPatientResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
    }
}