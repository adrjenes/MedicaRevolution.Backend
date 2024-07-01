using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Exceptions;
using MedicaRevolution.Domain.Interfaces;
using MedicaRevolution.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace MedicaRevolution.Application.Users.Patients.Queries.GetMyOneForm;

public class GetMyOneFormQueryHandler(ILogger<GetMyOneFormQueryHandler> logger, IPatientRepository patientRepository,
    IMapper mapper, IHttpContextAccessor httpContextAccessor, IBlobStorageService blobStorageService) : IRequestHandler<GetMyOneFormQuery, PatientFormDto>
{
    public async Task<PatientFormDto> Handle(GetMyOneFormQuery request, CancellationToken cancellationToken)
    {
        var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException("Brak userId");
        logger.LogInformation($"Getting patient form {request.Id}");
        var patientForm = await patientRepository.GetByIdAsync(request.Id)
                          ?? throw new NotFoundException(nameof(PatientForm), request.Id.ToString());
        var patientFormDto = mapper.Map<PatientFormDto>(patientForm);
        patientFormDto.PdfFileName = blobStorageService.GetBlobSasUrl(patientFormDto.PdfFileName);
        
        return patientFormDto;
    }
}