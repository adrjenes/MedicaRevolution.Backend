using MediatR;
using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using RudyGrzebien.Application.Users.Commands.AssignRole;

namespace RudyGrzebien.Application.Users.Handlers;
public class AssignRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignRoleCommand, AssignRoleResult>
{
    public async Task<AssignRoleResult> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null) return new AssignRoleResult { Success = false, Errors = new[] { "User not found" } };
        if (!await roleManager.RoleExistsAsync(request.Role))
        {
            return new AssignRoleResult { Success = false, Errors = new[] { "Role does not exist" } };
        }
        var result = await userManager.AddToRoleAsync(user, request.Role);
        if (result.Succeeded) return new AssignRoleResult { Success = true };
        return new AssignRoleResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
    }
}