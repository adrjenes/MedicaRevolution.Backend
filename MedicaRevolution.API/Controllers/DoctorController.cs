using MediatR;
using MedicaRevolution.Application.Users.Doctors.Queries;
using Microsoft.AspNetCore.Mvc;

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
}