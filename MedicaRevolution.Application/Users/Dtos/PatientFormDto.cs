namespace MedicaRevolution.Application.Users.Dtos;

public class PatientFormDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string PESEL { get; set; } 
    public string Email { get; set; } 
    public string PhoneNumber { get; set; } 
    public DateTime CreatedAt { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string DoctorConclusions { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? PdfFileName { get; set; } = string.Empty;
    public bool? isArchive { get; set; } 
    public DateTime? ResponseDateDoctor { get; set; }
}
