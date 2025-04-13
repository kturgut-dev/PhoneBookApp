using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Contact.Application.Abstract;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;
using PhoneBookApp.Shared.Application.API;

namespace PhoneBookApp.Contact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoController(IContactInfoService _service)
          : BaseController<Domain.Concrete.ContactInfo, ContactInfoCreateRequest, ContactInfoUpdateRequest, ContactInfoResponse>(_service)
    {
    }
}
