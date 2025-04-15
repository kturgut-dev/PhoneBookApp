using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Shared.Infrastructure.Context
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // Varsayılanı değiştir
            ChangeTracker.AutoDetectChangesEnabled = false; // Gereksiz değişiklik takibini kapat
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<IAuditableEntity> entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                Type clrType = entityType.ClrType;

                if (typeof(IAuditableEntity).IsAssignableFrom(clrType))
                {
                    ParameterExpression parameter = Expression.Parameter(clrType, "e");
                    MemberExpression isDeletedProp = Expression.Property(parameter, nameof(IAuditableEntity.IsDeleted));
                    BinaryExpression filter = Expression.Equal(isDeletedProp, Expression.Constant(false));
                    LambdaExpression lambda = Expression.Lambda(filter, parameter);

                    modelBuilder.Entity(clrType).HasQueryFilter(lambda);
                }
            }
        }
    }
}
