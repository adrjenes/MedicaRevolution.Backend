using MediatR;

namespace MedicaRevolution.Application.Users.Patients.Commands.SendForm;

public class SendFormCommand : IRequest<SendFormResult>
{
    public string Description { get; set; }
}

public class SendFormResult
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}