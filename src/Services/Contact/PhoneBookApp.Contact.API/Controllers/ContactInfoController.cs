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
        [HttpGet("list/{contactId:guid}")]
        public async Task<IActionResult> GetByContactId(Guid contactId, CancellationToken cancellationToken = default)
        {
            return ReturnResult(await _service.GetByContactIdAsync(contactId, cancellationToken));
        }
    }
}
