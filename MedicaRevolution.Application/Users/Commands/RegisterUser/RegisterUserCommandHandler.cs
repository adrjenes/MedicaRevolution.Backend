using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace RudyGrzebien.Application.Users.Commands.RegisterUser;
public class RegisterUserCommandHandler(UserManager<User> userManager) : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email
        };
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded) return new RegisterUserResult { Success = true };

        return new RegisterUserResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
    }
}
