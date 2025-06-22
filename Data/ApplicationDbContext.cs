using Microsoft.EntityFrameworkCore;
using PlantMonitorApi.Models;

namespace PlantMonitorApi.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<SensorData> SensorReadings { get; set; }

        public override int SaveChanges()
        {
            ApplyAuditingRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            ApplyAuditingRules();
            return base.SaveChangesAsync(ct);
        }

        private void ApplyAuditingRules()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = now;
                        break;

                    case EntityState.Deleted:
                        // soft-delete: mark DeletedAt instead of physical delete
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedAt = now;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<SensorData>()
              .HasQueryFilter(e => e.DeletedAt == null);

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
