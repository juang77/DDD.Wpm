using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Api.Infraestructure
{
    public class ClinicDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Consultation> Consultation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultation>(Consultation =>
            {
                Consultation.HasKey(x => x.Id);

                Consultation.Property(p => p.PatientId)
                            .HasConversion(y => y.Value, v => new PatientId(v));

                Consultation.OwnsOne(p => p.Diagnosis);
                Consultation.OwnsOne(p => p.Treatment);
                Consultation.OwnsOne(p => p.CurrentWeight);

                Consultation.OwnsMany(c => c.AdministeredDrugs, a =>
                {
                    a.WithOwner().HasForeignKey("ConsultationId");
                    a.OwnsOne(d => d.DrugId);
                    a.OwnsOne(d => d.Dose);
                });

                Consultation.OwnsMany(c => c.VitalSignsReadings, v =>
                {
                    v.WithOwner().HasForeignKey("ConsultationId");
                });
            });

            modelBuilder.HasDefaultSchema("Clinic");
        }
    }

    public static class ClinicDbContextExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
            context.Database.Migrate();
            context.Database.CloseConnection();
        }
    }
}


