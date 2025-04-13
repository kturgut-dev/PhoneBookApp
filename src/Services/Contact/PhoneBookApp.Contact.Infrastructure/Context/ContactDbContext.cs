using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Contact.Infrastructure.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Concrete.Contact> Contacts => Set<Domain.Concrete.Contact>();
        public DbSet<Domain.Concrete.ContactInfo> ContactInfos => Set<Domain.Concrete.ContactInfo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
