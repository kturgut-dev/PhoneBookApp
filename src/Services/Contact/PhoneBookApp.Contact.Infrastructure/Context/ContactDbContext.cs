using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Infrastructure.Context;

namespace PhoneBookApp.Contact.Infrastructure.Context
{
    public class ContactDbContext(DbContextOptions<ContactDbContext> options) : BaseDbContext(options)
    {
        public DbSet<Domain.Concrete.Contact> Contacts => Set<Domain.Concrete.Contact>();
        public DbSet<Domain.Concrete.ContactInfo> ContactInfos => Set<Domain.Concrete.ContactInfo>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
