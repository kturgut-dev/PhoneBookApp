using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBookApp.Shared.Infrastructure.Extensions
{
    public static class DbContextMigrationExtensions
    {
        public static async Task EnsureMigrationAsync<TContext>(this IServiceProvider serviceProvider)
            where TContext : DbContext
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            TContext context = scope.ServiceProvider.GetRequiredService<TContext>();

            bool databaseExists = await context.Database.CanConnectAsync();

            if (!databaseExists)
            {
                await context.Database.EnsureCreatedAsync();
            }
        }
    }
}
