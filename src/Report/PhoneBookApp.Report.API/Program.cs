using PhoneBookApp.Report.Application;
using PhoneBookApp.Report.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

Startup startup = new(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80); // gateway ile uyumlu olmalı
});

var app = builder.Build();

app.UseRouting(); // (ekle)
app.UseCors("AllowAll");
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

await app.Services.EnsureMigrationAsync<ReportDbContext>();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();