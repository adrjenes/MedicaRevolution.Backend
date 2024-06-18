using MediatR;

namespace RudyGrzebien.Application.Users.Commands.AddRole;
public class AddRoleCommand : IRequest<AddRoleResult>
{
    public string Role { get; set; }
}
public class AddRoleResult
{
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
