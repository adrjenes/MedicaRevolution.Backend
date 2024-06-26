using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Seeders;

internal class MedicaRevolutionSeeder(MedicaRevolutionDbContext dbContext) : IMedicaRevolutionSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}
