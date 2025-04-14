using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ocelot config dosyasını oku
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Swagger sadece Gateway için (Ocelot için değil)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.UseOcelot();

app.Run();