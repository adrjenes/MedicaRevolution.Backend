using MediatR;

namespace RudyGrzebien.Application.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<RegisterUserResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class RegisterUserResult
{
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
}