using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Application.Abstract;
using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Application.Concrete;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Contact.Application.Concrete
{
    public class ContactInfoService(
         IContactInfoRepository repository,
         IMapper mapper,
         ContactDbContext  context)
         : BaseService<ContactInfo, ContactInfoCreateRequest, ContactInfoUpdateRequest, ContactInfoResponse>(repository, mapper, context),
           IContactInfoService
    {
        public async Task<Result<List<ContactInfoResponse>>> GetByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default)
        {
            List<ContactInfo> infos = await _repository.GetAllAsync(x => x.ContactId == contactId, cancellationToken);
            List<ContactInfoResponse> response = _mapper.Map<List<ContactInfoResponse>>(infos);
            return Result<List<ContactInfoResponse>>.Success(response);
        }

    }
}
