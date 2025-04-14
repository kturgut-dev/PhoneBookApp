using PhoneBookApp.Contact.Application;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Contact.Infrastructure.DataSeed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Startup startup = new(app.Configuration, app.Environment);
startup.ConfigureServices(builder.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (IServiceScope? scope = app.Services.CreateScope())
{
    ContactDbContext? context = scope.ServiceProvider.GetRequiredService<ContactDbContext>();
    await ContactSeeder.SeedAsync(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
