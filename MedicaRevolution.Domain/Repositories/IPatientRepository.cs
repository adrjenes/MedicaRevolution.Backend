using MedicaRevolution.Domain.Entities;

namespace MedicaRevolution.Domain.Repositories;
public interface IPatientRepository
{
    Task SaveFormAsync(PatientForm form);
    Task<List<PatientForm>> GetPatientFormsByUserIdAsync(string userId);
}