using MediatR;
using MedicaRevolution.Application.Users.Dtos;

namespace MedicaRevolution.Application.Users.Patients.Queries.GetMyForms;
public class GetMyFormsQuery : IRequest<List<PatientFormDto>>
{
}
