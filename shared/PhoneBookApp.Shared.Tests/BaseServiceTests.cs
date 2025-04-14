using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Tests.Helpers;

namespace PhoneBookApp.Shared.Tests
{
    public class BaseServiceTests
    {
        private readonly TestDbContext _context;
        private readonly TestService _service;

        public BaseServiceTests()
        {
            DbContextOptions<TestDbContext> options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new TestDbContext(options);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TestCreateRequest, TestEntity>();
                cfg.CreateMap<TestUpdateRequest, TestEntity>();
                cfg.CreateMap<TestEntity, TestResponse>();
            });

            IMapper mapper = config.CreateMapper();
            TestEntityRepository repository = new TestEntityRepository(_context);

            _service = new TestService(repository, mapper, _context);
        }

        [Fact]
        public async Task AddAsync_Should_Return_SuccessResult()
        {
            TestCreateRequest dto = new TestCreateRequest("Kürşat");
            var result = await _service.AddAsync(dto);

            Assert.True(result.IsSuccess);
            Assert.Equal("Kürşat", result.Data?.Name);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Entity()
        {
            TestEntity entity = new TestEntity { Name = "Kürşat" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            var result = await _service.GetByIdAsync(entity.Id);

            Assert.True(result.IsSuccess);
            Assert.Equal("Kürşat", result.Data?.Name);
        }

        [Fact]
        public async Task DeleteAsync_Should_SoftDelete_Entity()
        {
            TestEntity entity = new TestEntity { Name = "Silinecek" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            var result = await _service.DeleteAsync(entity.Id);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_List()
        {
            await _context.TestEntities.AddRangeAsync(
                new TestEntity { Name = "1" },
                new TestEntity { Name = "2" });
            await _context.SaveChangesAsync();

            var result = await _service.GetAllAsync();
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count);
        }
    }
}
