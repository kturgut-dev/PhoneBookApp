namespace PhoneBookApp.Shared.Core.Abstract
{

    //public interface IAuditableEntity<TId> : IEntity<TId>
    //{
    //    DateTime CreatedDate { get; set; }

    //    DateTime? LastModifiedDate { get; set; }

    //    /// <summary>
    //    /// Soft delete flag.
    //    /// </summary>
    //    bool IsDeleted { get; set; }
    //}

    public interface IAuditableEntity : IEntity<Guid>
    {
        DateTime CreatedDate { get; set; }

        DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Soft delete flag.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
