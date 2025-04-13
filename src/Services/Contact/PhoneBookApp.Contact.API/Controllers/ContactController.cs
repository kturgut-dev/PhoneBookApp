using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Contact.Application.Abstract;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact;
using PhoneBookApp.Shared.Application.API;

namespace PhoneBookApp.Contact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController(IContactService _service)
           : BaseController<Domain.Concrete.Contact, ContactCreateRequest, ContactUpdateRequest, ContactResponse>(_service)
    {
        [HttpGet("detail/{id:guid}")]
        public async Task<IActionResult> GetDetailById(Guid id, CancellationToken cancellationToken = default)
        {
            return ReturnResult(await _service.GetDetailByIdAsync(id, cancellationToken));
        }
    }
}
