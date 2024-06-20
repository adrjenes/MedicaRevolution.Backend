using MediatR;
using Microsoft.AspNetCore.Identity;
using RudyGrzebien.Application.Users.Commands.AddRole;

namespace RudyGrzebien.Application.Users.Handlers;
public class AddRoleCommandHandler(RoleManager<IdentityRole> roleManager) : IRequestHandler<AddRoleCommand, AddRoleResult>
{
    public async Task<AddRoleResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        if (!await roleManager.RoleExistsAsync(request.Role))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(request.Role));
            if (result.Succeeded) return new AddRoleResult { Success = true };
            return new AddRoleResult { Success = false, Errors = result.Errors.Select(e => e.Description)};
        }
        return new AddRoleResult { Success = false, Errors = new[] { "Role already exists" } };
    }
}