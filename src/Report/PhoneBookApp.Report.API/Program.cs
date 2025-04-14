using PhoneBookApp.Report.Application;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();