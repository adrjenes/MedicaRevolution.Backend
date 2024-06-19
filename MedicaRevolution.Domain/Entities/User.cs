using Microsoft.AspNetCore.Identity;

namespace MedicaRevolution.Domain.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
    public ICollection<PatientForm> PatientForms { get; set; } = new List<PatientForm>();
}

