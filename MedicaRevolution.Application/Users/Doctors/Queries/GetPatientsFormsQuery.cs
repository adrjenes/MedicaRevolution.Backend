using MediatR;
using MedicaRevolution.Application.Users.Dtos;

namespace MedicaRevolution.Application.Users.Doctors.Queries;

public class GetPatientFormsQuery : IRequest<List<PatientFormDto>>
{
}