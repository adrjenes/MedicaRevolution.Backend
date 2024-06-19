namespace MedicaRevolution.Domain.Entities;

public class PatientForm
{
    public int Id { get; set; }
    public string PatientId { get; set; }
    public string Description { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public User Patient { get; set; }
}