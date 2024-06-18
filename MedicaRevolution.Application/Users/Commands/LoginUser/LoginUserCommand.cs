using MediatR;

namespace RudyGrzebien.Application.Users.Commands.LoginUser;
public class LoginUserCommand : IRequest<LoginUserResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserResult
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
