using Microsoft.EntityFrameworkCore;
using WebAtrio.UserManagement.Models.Entities;

namespace WebAtrio.UserManagement.Infrastructure
{
    public class UMDbContext : DbContext
    {
        public UMDbContext(DbContextOptions<UMDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        // This method is called by SaveChanges and SaveChangesAsync to apply custom
        // logic to entities that are being added or updated in the database.
        // Automatic timestamping is not working for update yet.
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if (entity.Entity is IBaseEntity baseEntity)
                    {
                        baseEntity.CreatedAt = DateTime.UtcNow;
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                    }
                }
                else if (entity.State == EntityState.Modified)
                {
                    if (entity.Entity is IBaseEntity baseEntity)
                    {
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
