using System.Security.Cryptography;

namespace PhoneBookApp.Shared.Core.Abstract
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }

    //public interface IEntity : IEntity<Guid>
    //{
    //}
}
