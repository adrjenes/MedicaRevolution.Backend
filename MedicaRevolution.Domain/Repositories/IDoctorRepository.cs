using MedicaRevolution.Domain.Entities;

namespace MedicaRevolution.Domain.Repositories;

public interface IDoctorRepository
{
    Task<List<PatientForm>> GetAllPatientFormsAsync();
}