using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Shared.Core.Concrete
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
