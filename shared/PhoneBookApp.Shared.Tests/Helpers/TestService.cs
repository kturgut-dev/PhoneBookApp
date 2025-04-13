using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Application.Concrete;
using PhoneBookApp.Shared.Infrastructure.Abstract;

namespace PhoneBookApp.Shared.Tests.Helpers
{
    public class TestService : BaseService<TestEntity, TestCreateRequest, TestUpdateRequest, TestResponse>
    {
        public TestService(IRepository<TestEntity> repository, IMapper mapper, DbContext context)
            : base(repository, mapper, context) { }
    }
}
