using MediatR;
using MedicaRevolution.Application.Users.Doctors.Commands;
using MedicaRevolution.Application.Users.Doctors.Queries;
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
    public async Task<IActionResult> GetPatientForms()
    {
        var query = new GetPatientFormsQuery();
        var result = await _mediator.Send(query);
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
}