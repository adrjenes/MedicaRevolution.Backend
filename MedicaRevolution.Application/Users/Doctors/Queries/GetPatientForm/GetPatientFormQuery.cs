using MediatR;
using MedicaRevolution.Application.Users.Dtos;

namespace MedicaRevolution.Application.Users.Doctors.Queries.GetPatientForm;

public class GetPatientFormQuery(int id) : IRequest<PatientDto>
{
    public int Id { get; } = id;
}
