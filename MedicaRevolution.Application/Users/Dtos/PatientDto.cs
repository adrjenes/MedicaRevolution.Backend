namespace MedicaRevolution.Application.Users.Dtos;

public class PatientDto
{
    public string Description { get; set; } = string.Empty;
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string PESEL { get; set; } 
    public string Email { get; set; } 
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } 
    public string Diagnosis { get; set; } = string.Empty;
    public string DoctorConclusions { get; set; } = string.Empty;
    public string PdfFileName { get; set; } = string.Empty;
    public bool isArchive { get; set; } = false;
    public DateTime ResponseDateDoctor { get; set; }
}
