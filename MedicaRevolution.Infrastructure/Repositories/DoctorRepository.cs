using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Repositories;
internal class DoctorRepository(MedicaRevolutionDbContext dbContext) : IDoctorRepository
{
    public async Task<List<PatientForm>> GetAllPatientFormsAsync(bool? isArchive)
    {
        var query = dbContext.PatientForms.AsQueryable();

        if (isArchive.HasValue)
        {
            query = query.Where(p => p.isArchive == isArchive.Value);
        }

        return await query.ToListAsync();
    }
    public async Task<PatientForm?> GetByIdAsync(int id)
    {
        var patient = await dbContext.PatientForms
            .FirstOrDefaultAsync(x => x.Id == id);
        return patient;
    }
    public Task SaveChanges() => dbContext.SaveChangesAsync();
}