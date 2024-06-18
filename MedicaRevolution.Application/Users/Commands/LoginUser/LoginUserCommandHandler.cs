using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RudyGrzebien.Application.Users.Commands.LoginUser;
public class LoginUserCommandHandler(UserManager<User> userManager, IConfiguration configuration) : IRequestHandler<LoginUserCommand, LoginUserResult>
{
    public async Task<LoginUserResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                expires: DateTime.Now.AddMinutes(double.Parse(configuration["JWT:ExpiryMinutes"]!)),
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                SecurityAlgorithms.HmacSha256)
            );
            return new LoginUserResult
            {
                Success = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
        return new LoginUserResult
        {
            Success = false,
            Errors = new[] { "Invalid login attempt" }
        };
    }
}