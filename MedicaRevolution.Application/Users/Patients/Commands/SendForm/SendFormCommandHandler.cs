using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Patients.Commands.SendForm;
using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

public class SendFormCommandHandler(UserManager<User> userManager, IPatientRepository patientRepository, IHttpContextAccessor httpContextAccessor, 
    ILogger<SendFormCommandHandler> logger, IMapper mapper) : IRequestHandler<SendFormCommand, SendFormResult>
{
    public async Task<SendFormResult> Handle(SendFormCommand request, CancellationToken cancellationToken)
    {
        var email = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        var patient = await userManager.FindByEmailAsync(email);
        var patientForm = mapper.Map<PatientForm>(patient);
        patientForm.Description = request.Description;
        await patientRepository.SaveFormAsync(patientForm);
        return new SendFormResult { Success = true };
    }
}