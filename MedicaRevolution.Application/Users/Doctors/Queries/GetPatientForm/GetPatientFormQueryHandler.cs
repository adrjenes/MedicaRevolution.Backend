using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Exceptions;
using MedicaRevolution.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicaRevolution.Application.Users.Doctors.Queries.GetPatientForm;

public class GetPatientFormQueryHandler(ILogger<GetPatientFormQueryHandler> logger,
    IDoctorRepository doctorRepository,
    IMapper mapper) : IRequestHandler<GetPatientFormQuery, PatientDto>
{
    public async Task<PatientDto> Handle(GetPatientFormQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting patient {request.Id}");
        var patient = await doctorRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(PatientForm), request.Id.ToString());
        var patientDto = mapper.Map<PatientDto>(patient);
        return patientDto;
    }
}
