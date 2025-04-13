using AutoMapper;
using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;

namespace PhoneBookApp.Contact.Application.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            // Contact
            CreateMap<ContactCreateRequest, Domain.Concrete.Contact>();
            CreateMap<ContactUpdateRequest, Domain.Concrete.Contact>();
            CreateMap<Domain.Concrete.Contact, ContactResponse>();

            // ContactInfo
            CreateMap<ContactInfoCreateRequest, ContactInfo>();
            CreateMap<ContactInfoUpdateRequest, ContactInfo>();
            CreateMap<ContactInfo, ContactInfoResponse>();
        }
    }
}
