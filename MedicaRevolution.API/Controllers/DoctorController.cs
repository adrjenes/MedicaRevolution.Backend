using MediatR;
using MedicaRevolution.Application.Users.Doctors.Commands.UpdatePatient;
using MedicaRevolution.Application.Users.Doctors.Queries.GetPatientForm;
using MedicaRevolution.Application.Users.Doctors.Queries.GetPatientsForms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/doctor")]
[Authorize(Roles = "Doctor")]
public class DoctorController(IMediator mediator) : ControllerBase
{
    [HttpGet("patient-forms")]
    public async Task<IActionResult> GetPatientForms([FromQuery] bool? isArchive)
    {
        var query = new GetPatientsFormsQuery { IsArchive = isArchive };
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetPatientFormQuery(id));
        return Ok(result);
    }
    [HttpPatch("update-and-upload/{id}")]
    public async Task<IActionResult> UpdatePatientForm([FromRoute] int id,[FromForm] UpdatePatientFormCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}