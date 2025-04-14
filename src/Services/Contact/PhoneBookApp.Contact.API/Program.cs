using PhoneBookApp.Contact.Application;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Contact.Infrastructure.DataSeed;
using PhoneBookApp.Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

Startup startup = new(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.Services.EnsureMigrationAsync<ContactDbContext>();

using (IServiceScope scope = app.Services.CreateScope())
{
    ContactDbContext context = scope.ServiceProvider.GetRequiredService<ContactDbContext>();

    await ContactSeeder.SeedAsync(context);
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();