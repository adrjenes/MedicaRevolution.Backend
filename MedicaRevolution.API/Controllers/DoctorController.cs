using MediatR;
using MedicaRevolution.Application.Users.Doctors.Commands;
using MedicaRevolution.Application.Users.Doctors.Commands.UpdatePatient;
using MedicaRevolution.Application.Users.Doctors.Commands.UploadPatient;
using MedicaRevolution.Application.Users.Doctors.Queries;
using MedicaRevolution.Application.Users.Doctors.Queries.GetPatientForm;
using MedicaRevolution.Application.Users.Doctors.Queries.GetPatientsForms;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

[ApiController]
[Route("api/doctor")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;
    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("patient-forms")]
    public async Task<IActionResult> GetPatientForms([FromQuery] bool? isArchive)
    {
        var query = new GetPatientsFormsQuery { IsArchive = isArchive };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetPatientFormQuery(id));
        return Ok(result);
    }
    [HttpPost("logo/{id}")]
    public async Task<IActionResult> UploadLogo([FromRoute] int id, IFormFile file)
    {
        using var stream = file.OpenReadStream();
        var command = new UploadPatientFormCommand()
        {
            Id = id,
            FileName = $"{id}-{file.FileName}",
            File = stream
        };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPatch("update-and-upload/{id}")]
    public async Task<IActionResult> UpdatePatientForm([FromRoute] int id,[FromForm] UpdatePatientFormCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }
}