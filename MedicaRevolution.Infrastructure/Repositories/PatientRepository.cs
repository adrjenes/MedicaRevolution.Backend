using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Repositories;
public class PatientRepository : IPatientRepository
{
    private readonly MedicaRevolutionDbContext _dbContext;

    public PatientRepository(MedicaRevolutionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveFormAsync(PatientForm form)
    {
        _dbContext.PatientForms.Add(form);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<List<PatientForm>> GetPatientFormsByUserIdAsync(string userId)
    {
        return await _dbContext.PatientForms
            .Where(pf => pf.PatientId == userId)
            .ToListAsync();
    }
}