using MediatR;
using MedicaRevolution.Application.Users.Dtos;

namespace MedicaRevolution.Application.Users.Patients.Queries.GetMyOneForm;
public class GetMyOneFormQuery(int id) : IRequest<PatientFormDto>
{
    public int Id { get; } = id;
}
