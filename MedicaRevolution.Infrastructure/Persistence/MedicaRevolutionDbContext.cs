using MedicaRevolution.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicaRevolution.Infrastructure.Persistence;

public class MedicaRevolutionDbContext : IdentityDbContext<User>
{
    public MedicaRevolutionDbContext(DbContextOptions<MedicaRevolutionDbContext> options)
        : base(options)
    {
    }
    public DbSet<PatientForm> PatientForms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PatientForm>()
            .HasOne(pf => pf.Patient)
            .WithMany(u => u.PatientForms) // Definiowanie relacji jeden-do-wielu
            .HasForeignKey(pf => pf.PatientId)
            .HasPrincipalKey(u => u.Id);
    }
}