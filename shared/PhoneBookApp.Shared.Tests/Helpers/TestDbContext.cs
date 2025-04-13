using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Infrastructure.Context;

namespace PhoneBookApp.Shared.Tests.Helpers
{
    public class TestDbContext : BaseDbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public DbSet<TestEntity> TestEntities => Set<TestEntity>();
    }
}
