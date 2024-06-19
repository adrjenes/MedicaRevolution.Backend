using MediatR;

namespace MedicaRevolution.Application.Users.Patients.Commands.Register;

public class RegisterPatientCommand : IRequest<RegisterPatientResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}

public class RegisterPatientResult
{
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
}