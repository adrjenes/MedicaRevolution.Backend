using MediatR;
using Microsoft.AspNetCore.Http;

namespace MedicaRevolution.Application.Users.Doctors.Commands.UpdatePatient;

public class UpdatePatientFormCommand : IRequest
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Diagnosis { get; set; }
    public string? DoctorConclusions { get; set; }
    public bool isArchive { get; set; }
    public IFormFile? File { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
    public DateTime? ResponseDateDoctor { get; set; }
}
