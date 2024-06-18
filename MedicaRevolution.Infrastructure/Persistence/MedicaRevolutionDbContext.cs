using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Persistence;

internal class MedicaRevolutionDbContext(DbContextOptions<MedicaRevolutionDbContext> options) : IdentityDbContext<User>(options)
{
    
}
