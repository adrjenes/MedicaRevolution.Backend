using MediatR;
using MedicaRevolution.Application.Users.Dtos;

namespace MedicaRevolution.Application.Users.Doctors.Queries.GetPatientsForms;

public class GetPatientsFormsQuery : IRequest<List<PatientFormDto>>
{
    public bool? IsArchive { get; set; }
}