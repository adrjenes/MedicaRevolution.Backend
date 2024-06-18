using MediatR;
namespace RudyGrzebien.Application.Users.Commands.AssignRole;
public class AssignRoleCommand : IRequest<AssignRoleResult>
{
    public string Email { get; set; }
    public string Role { get; set; }
}

public class AssignRoleResult
{
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
