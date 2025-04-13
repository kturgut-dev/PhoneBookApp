using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Tests.Helpers;

namespace PhoneBookApp.Shared.Tests
{
    public class BaseRepositoryTests
    {
        private readonly TestDbContext _context;
        private readonly TestEntityRepository _repository;

        public BaseRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new TestDbContext(options);
            _repository = new TestEntityRepository(_context);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Entity()
        {
            var entity = new TestEntity { Name = "Test Add" };

            var result = await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            Assert.NotNull(result);
            Assert.Equal("Test Add", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Entity()
        {
            var entity = new TestEntity { Name = "Test Find" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            var result = await _repository.GetByIdAsync(entity.Id);

            Assert.NotNull(result);
            Assert.Equal("Test Find", result?.Name);
        }

        [Fact]
        public async Task UpdateAsync_Should_Modify_Entity()
        {
            var entity = new TestEntity { Name = "Old Name" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            entity.Name = "Updated Name";
            var result = await _repository.UpdateAsync(entity);
            await _context.SaveChangesAsync();

            var updated = await _context.TestEntities.FindAsync(entity.Id);
            Assert.True(result);
            Assert.Equal("Updated Name", updated?.Name);
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Entity()
        {
            var entity = new TestEntity { Name = "To Delete" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            var result = await _repository.DeleteAsync(entity.Id);
            await _context.SaveChangesAsync();

            var deleted = await _context.TestEntities.FindAsync(entity.Id);
            Assert.True(result);
            Assert.NotNull(deleted);
            Assert.True(deleted.IsDeleted);
            Assert.NotNull(deleted.LastModifiedDate);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Entities()
        {
            await _context.TestEntities.AddRangeAsync(new[]
            {
                new TestEntity { Name = "Item 1" },
                new TestEntity { Name = "Item 2" }
            });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task DeleteAsync_Should_SoftDelete_Entity()
        {
            var entity = new TestEntity { Name = "To be soft deleted" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            var deleted = await _repository.DeleteAsync(entity.Id);
            await _context.SaveChangesAsync();

            // Silmediği için tekrar bulabilirim
            var result = await _context.TestEntities
                .IgnoreQueryFilters() // filter kaldır
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            // Assert
            Assert.True(deleted);
            Assert.NotNull(result);
            Assert.True(result!.IsDeleted);
            Assert.NotNull(result.LastModifiedDate);
        }
    }
}
