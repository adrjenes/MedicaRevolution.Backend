using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Repositories;
internal class PatientRepository(MedicaRevolutionDbContext dbContext) : IPatientRepository
{
    public async Task SaveFormAsync(PatientForm form)
    {
        dbContext.PatientForms.Add(form);
        await dbContext.SaveChangesAsync();
    }
    public async Task<List<PatientForm>> GetPatientFormsByUserIdAsync(string userId)
    {
        return await dbContext.PatientForms
            .Where(pf => pf.PatientId == userId)
            .ToListAsync();
    }
    public async Task<PatientForm?> GetByIdAsync(int id)
    {
        var patient = await dbContext.PatientForms
            .FirstOrDefaultAsync(x => x.Id == id);
        return patient;
    }
}