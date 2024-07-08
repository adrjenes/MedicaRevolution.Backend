using MediatR;
using MedicaRevolution.Application.Users.Patients.Commands.Register;
using MedicaRevolution.Application.Users.Patients.Commands.SendForm;
using MedicaRevolution.Application.Users.Patients.Queries.GetMyForms;
using MedicaRevolution.Application.Users.Patients.Queries.GetMyOneForm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicaRevolution.API.Controllers;
[ApiController]
[Route("api/patient")]
[Authorize(Roles = "Patient")]
public class PatientController(IMediator mediator) : ControllerBase
{
    [HttpPost("register-patient")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { token = result.Token }); 
        return BadRequest(result.Errors);
    }
    [HttpPost("send-form")]
    public async Task<IActionResult> SendForm([FromBody] SendFormCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Success) return Ok(new { message = "Form sent successfully" });
        return BadRequest(new { message = result.ErrorMessage });
    }

    [HttpGet("my-forms")]
    public async Task<IActionResult> GetMyPatientForms()
    {
        var query = new GetMyFormsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("my-forms/{id}")]
    public async Task<IActionResult> GetMyOnePatientForm([FromRoute] int id)
    {
        var result = await mediator.Send(new GetMyOneFormQuery(id));
        return Ok(result);
    }
}
