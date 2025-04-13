using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Contact.Application.Mapping;
using PhoneBookApp.Contact.Application.Validators;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Contact.Infrastructure.Concrete;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Repositories.Abstract;
using PhoneBookApp.Shared.Infrastructure.Repositories.Concrete;

namespace PhoneBookApp.Contact.Application
{
    public class Startup(IConfiguration _configuration, IHostEnvironment hostEnvironment)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ContactDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));


            // Repository
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            //// Services
            //services.AddScoped<IContactService, ContactService>();
            //services.AddScoped<IContactInfoService, ContactInfoService>();

            // AutoMapper
            services.AddAutoMapper(typeof(ContactProfile).Assembly);

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<ContactCreateRequestValidator>();
        }
    }
}
