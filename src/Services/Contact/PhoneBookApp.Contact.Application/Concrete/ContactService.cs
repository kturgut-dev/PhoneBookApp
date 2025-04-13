using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Application.Abstract;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Shared.Application.Concrete;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Contact.Application.Concrete
{
    public class ContactService(
        IContactRepository repository,
        IMapper mapper,
        DbContext context)
        : BaseService<Domain.Concrete.Contact, ContactCreateRequest, ContactUpdateRequest, ContactResponse>(repository, mapper, context),
          IContactService
    {
        private readonly IContactRepository _contactRepository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<ContactWithInfoResponse?>> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            Domain.Concrete.Contact? entity = await _contactRepository.GetDetailByIdAsync(id, cancellationToken);
            if (entity == null)
                return Result<ContactWithInfoResponse?>.Fail("Detail not found.");

            ContactWithInfoResponse response = _mapper.Map<ContactWithInfoResponse>(entity);
            return Result<ContactWithInfoResponse?>.Success(response);
        }
    }
}
