using MediatR;

namespace MedicaRevolution.Application.Users.Doctors.Commands.UploadPatient;

public class UploadPatientFormCommand : IRequest
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public Stream File { get; set; }
}
