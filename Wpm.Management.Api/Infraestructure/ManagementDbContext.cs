using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infraestructure
{
    public class ManagementDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>().HasKey(x => x.Id);
            modelBuilder.Entity<Pet>()
                        .Property(p => p.BreedId)
                        .HasConversion(v => v.Value, v => BreedId.Create(v));
            modelBuilder.Entity<Pet>().OwnsOne(x => x.Weight);

            modelBuilder.HasDefaultSchema("Management");
        }
    }

    public static class ManagementDbContextExtensions 
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ManagementDbContext>();
            context.Database.Migrate();
        }
    }
}


