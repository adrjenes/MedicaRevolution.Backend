using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Repositories;

namespace MedicaRevolution.Application.Users.Doctors.Queries;

public class GetPatientFormsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) : IRequestHandler<GetPatientFormsQuery, List<PatientFormDto>>
{
    public async Task<List<PatientFormDto>> Handle(GetPatientFormsQuery request, CancellationToken cancellationToken)
    {
        var patientForms = await doctorRepository.GetAllPatientFormsAsync();
        return mapper.Map<List<PatientFormDto>>(patientForms);
    }
}