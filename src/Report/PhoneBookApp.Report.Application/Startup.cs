using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Report.Application.Concrete;
using PhoneBookApp.Report.Application.Mapping;
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


            // Repository
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportDetailRepository, ReportDetailRepository>();

            // Services
            services.AddScoped<IReportService, ReportService>();

            // AutoMapper
            services.AddAutoMapper(typeof(ReportProfile).Assembly);

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<ReportCreateRequestValidator>();
        }
    }
}
