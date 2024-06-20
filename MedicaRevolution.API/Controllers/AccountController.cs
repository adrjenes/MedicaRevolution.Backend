using MediatR;
using Microsoft.AspNetCore.Mvc;
using RudyGrzebien.Application.Users.Commands.AddRole;
using RudyGrzebien.Application.Users.Commands.AssignRole;
using RudyGrzebien.Application.Users.Commands.LoginUser;

namespace MedicaRevolution.API.Controllers;
[ApiController]
[Route("api/account")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { Token = result.Token });
        return Unauthorized(result.Errors);
    }

    [HttpPost("add-role")]
    public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { message = "Role added successfully" });
        return BadRequest(result.Errors);
    }
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
    {
        var result = await mediator.Send(command);

        if (result.Success)
        {
            return Ok(new { message = "Role assigned successfully" });
        }

        return BadRequest(result.Errors);
    }
    
}
