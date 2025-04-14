using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Report.Application.Concrete;
using PhoneBookApp.Report.Application.Mapping;
using PhoneBookApp.Report.Application.Messaging.Consumers;
using PhoneBookApp.Report.Application.Validators;
using PhoneBookApp.Report.Infrastructure.Abstract;
using PhoneBookApp.Report.Infrastructure.Concrete;
using PhoneBookApp.Report.Infrastructure.Context;

namespace PhoneBookApp.Report.Application
{
    public class Startup(IConfiguration _configuration, IHostEnvironment hostEnvironment)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ReportDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<ReportGeneratedEventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    string host = _configuration["RabbitMq:Host"];
                    ushort port = ushort.Parse(_configuration["RabbitMq:Port"] ?? "5672");

                    cfg.Host("rabbitmq", h =>
                    {
                        h.Username(_configuration["RabbitMq:Username"]);
                        h.Password(_configuration["RabbitMq:Password"]);
                    });

                    cfg.ReceiveEndpoint("report-generated-event-queue", e =>
                    {
                        e.ConfigureConsumer<ReportGeneratedEventConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            // Services
            services.AddScoped<IReportService, ReportService>();

            // Repository
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportDetailRepository, ReportDetailRepository>();

            // AutoMapper
            services.AddAutoMapper(typeof(ReportProfile).Assembly);

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<ReportCreateRequestValidator>();
        }
    }
}
