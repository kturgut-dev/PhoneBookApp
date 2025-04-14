using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Contact.Infrastructure.Context
{
    public static class ContactDbContextFactory
    {
        public static ContactDbContext Create()
        {
            DbContextOptions<ContactDbContext> options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            ContactDbContext context = new ContactDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
