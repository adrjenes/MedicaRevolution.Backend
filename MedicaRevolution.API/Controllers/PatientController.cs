using MediatR;
using MedicaRevolution.Application.Users.Patients.Commands.Register;
using MedicaRevolution.Application.Users.Patients.Commands.SendForm;
using Microsoft.AspNetCore.Mvc;

namespace MedicaRevolution.API.Controllers;

public class PatientController(IMediator mediator) : ControllerBase
{
    [HttpPost("register-patient")]
    public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { message = "Patient registered successfully" });
        return BadRequest(result.Errors);
    }
    [HttpPost("send-form")]
    public async Task<IActionResult> SendForm([FromBody] SendFormCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { message = "Form sent successfully" });
        return BadRequest(new { message = result.ErrorMessage });
    }
}
