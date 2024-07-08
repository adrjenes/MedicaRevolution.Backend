using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Repositories;

namespace MedicaRevolution.Application.Users.Doctors.Queries.GetPatientsForms;
public class GetPatientsFormsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) : IRequestHandler<GetPatientsFormsQuery, List<PatientFormDto>>
{
    public async Task<List<PatientFormDto>> Handle(GetPatientsFormsQuery request, CancellationToken cancellationToken)
    {
        var patientForms = await doctorRepository.GetAllPatientFormsAsync(request.IsArchive);
        return mapper.Map<List<PatientFormDto>>(patientForms);
    }
}