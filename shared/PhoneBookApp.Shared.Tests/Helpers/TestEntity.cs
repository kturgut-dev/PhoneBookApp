using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Shared.Tests.Helpers
{
    public class TestEntity : IAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    public record TestCreateRequest(string Name);
    public record TestUpdateRequest(Guid Id, string Name);
    public record TestResponse(Guid Id, string Name);
}
