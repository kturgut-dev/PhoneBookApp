using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Shared.Core.Concrete
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
