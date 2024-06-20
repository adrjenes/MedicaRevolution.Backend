using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Repositories;
internal class DoctorRepository(MedicaRevolutionDbContext dbContext) : IDoctorRepository
{
    public async Task<List<PatientForm>> GetAllPatientFormsAsync()
    {
        return await dbContext.PatientForms.ToListAsync();
    }
}