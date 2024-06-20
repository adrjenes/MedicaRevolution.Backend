using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace RudyGrzebien.Application.Users.Commands.LoginUser;
public class LoginUserCommandHandler(UserManager<User> userManager, TokenService tokenService) : IRequestHandler<LoginUserCommand, LoginUserResult>
{
    public async Task<LoginUserResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
        {
            var token = tokenService.GenerateToken(user);
            return new LoginUserResult
            {
                Success = true,
                Token = token
            };
        }
        return new LoginUserResult
        {
            Success = false,
            Errors = new[] { "Invalid login attempt" }
        };
    }
}