using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Application.Concrete;
using PhoneBookApp.Contact.Application.Mapping;
using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact;
using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Contact.Infrastructure.Concrete;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Core.Utilities.Result;
using PhoneBookApp.Shared.Infrastructure.Context;

namespace PhoneBookApp.Contact.Tests.Services
{
    public class ContactServiceTests
    {
        private readonly IContactRepository _repository;
        private readonly ContactService _service;
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public ContactServiceTests()
        {
            DbContextOptions<ContactDbContext> options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ContactDbContext(options);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContactProfile());
            });

            _mapper = mapperConfig.CreateMapper();

            _repository = new ContactRepository((ContactDbContext)_context);
            _service = new ContactService(_repository, _mapper, _context);
        }

        [Fact]
        public async Task GetDetailByIdAsync_Should_Return_Contact_With_All_ContactInfoTypes()
        {
            Domain.Concrete.Contact contact = new Domain.Concrete.Contact
            {
                Id = Guid.NewGuid(),
                Name = "Kürşat",
                Surname = "Turgut",
                Company = "Test A.Ş.",
                ContactInfos = new List<ContactInfo>
                {
                    new ContactInfo { InfoType = ContactInfoType.PhoneNumber, Content = "0555 111 11 11", Title = "Cep" },
                    new ContactInfo { InfoType = ContactInfoType.Email, Content = "kursat@test.com", Title = "İş Mail" },
                    new ContactInfo { InfoType = ContactInfoType.Location, Content = "İstanbul", Title = "Ofis" },
                    new ContactInfo { InfoType = ContactInfoType.Anniversary, Content = "01.01.2020", Title = "Yıldönümü" }
                }
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            Result<ContactWithInfoResponse?> result = await _service.GetDetailByIdAsync(contact.Id);

            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data!.Name.Should().Be("Kürşat");
            result.Data.ContactInfos.Should().HaveCount(4);
            result.Data.ContactInfos.Select(x => x.InfoType).Should().Contain(new[]
            {
                ContactInfoType.PhoneNumber, ContactInfoType.Email, ContactInfoType.Location, ContactInfoType.Anniversary
            });
        }

        [Fact]
        public async Task GetDetailByIdAsync_Should_Return_Fail_When_Contact_Not_Found()
        {
            Result<ContactWithInfoResponse?> result = await _service.GetDetailByIdAsync(Guid.NewGuid());

            result.IsSuccess.Should().BeFalse();
            result.Data.Should().BeNull();
            result.Message.Should().Be("Detail not found.");
        }
    }
}
