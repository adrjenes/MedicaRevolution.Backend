using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Persistence;

internal class MedicaRevolutionDbContext : DbContext
{
    public MedicaRevolutionDbContext(DbContextOptions<MedicaRevolutionDbContext> options) : base(options)
    {
    }
}
