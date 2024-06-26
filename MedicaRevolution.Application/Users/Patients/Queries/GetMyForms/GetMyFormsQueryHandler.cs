using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Doctors.Queries;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Interfaces;
using MedicaRevolution.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MedicaRevolution.Application.Users.Patients.Queries.GetMyForms;

public class GetMyFormsQueryHandler(IPatientRepository patientFormRepository, 
    IMapper mapper, 
    IHttpContextAccessor httpContextAccessor,
    IBlobStorageService blobStorageService
    ) : IRequestHandler<GetMyFormsQuery, List<PatientFormDto>>
{
    public async Task<List<PatientFormDto>> Handle(GetMyFormsQuery request, CancellationToken cancellationToken)
    {
        var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException("Brak userId");

        var patientForms = await patientFormRepository.GetPatientFormsByUserIdAsync(userId);
        var forms = mapper.Map<List<PatientFormDto>>(patientForms);

        foreach (var form in forms)
        {
            form.PdfFileName = blobStorageService.GetBlobSasUrl(form.PdfFileName);
        }
        return forms;
    }
}