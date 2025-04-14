using PhoneBookApp.Shared.Infrastructure.Concrete;

namespace PhoneBookApp.Shared.Tests.Helpers
{
    public class TestEntityRepository : BaseRepository<TestEntity>
    {
        public TestEntityRepository(TestDbContext context) : base(context) { }
    }
}
