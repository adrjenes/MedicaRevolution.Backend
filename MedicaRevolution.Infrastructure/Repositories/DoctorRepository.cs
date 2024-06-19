using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly MedicaRevolutionDbContext _dbContext;

    public DoctorRepository(MedicaRevolutionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}