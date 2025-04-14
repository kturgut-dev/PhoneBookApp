using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Contact.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Contact.Infrastructure.DataSeed
{
    public static class ContactSeeder
    {
        public static async Task SeedAsync(ContactDbContext context)
        {
            if (context.Contacts.Any()) return;

            Domain.Concrete.Contact contact = new Domain.Concrete.Contact
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Kürşat",
                Surname = "Turgut",
                Company = "TurgutSoft",
                Nickname = "KT",
                Website = "https://kursatturgut.com",
                Note = "Kurucu & CEO",
                ContactInfos = new List<ContactInfo>
                {
                    new ContactInfo
                    {
                        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                        InfoType = ContactInfoType.Email,
                        Title = "İş Mail",
                        Content = "kursat@turgutsoft.com"
                    },
                    new ContactInfo
                    {
                        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                        InfoType = ContactInfoType.PhoneNumber,
                        Title = "Cep",
                        Content = "+90 532 000 00 00"
                    },
                    new ContactInfo
                    {
                        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                        InfoType = ContactInfoType.Location,
                        Title = "Ofis",
                        Content = "İstanbul, Türkiye"
                    }
                }
            };

            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();
        }
    }
}
