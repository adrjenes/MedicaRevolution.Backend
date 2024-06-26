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
    public async Task<PatientForm?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.PatientForms
            .FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }
    public Task SaveChanges() => dbContext.SaveChangesAsync();
}