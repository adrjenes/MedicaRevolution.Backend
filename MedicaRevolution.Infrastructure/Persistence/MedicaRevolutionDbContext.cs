using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Persistence;

internal class MedicaRevolutionDbContext(DbContextOptions<MedicaRevolutionDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<PatientForm> PatientForms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PatientForm>()
            .HasOne(pf => pf.Patient)
            .WithMany(u => u.PatientForms)
            .HasForeignKey(pf => pf.PatientId)
            .HasPrincipalKey(u => u.Id);
    }
}