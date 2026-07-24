using Invoicing.Contract.Dtos;
using Invoicing.Domain.Entities;
using Invoicing.Domain.ValueObjects;

namespace Invoicing.Business
{
    public class DemoDataDtoMapper
    {
        public AddressDto MapAddressToDto(Address a)
        {
            return new AddressDto()
            {
                Street = a.Street,
                City = a.City,
                PostalCode = a.PostalCode,
                HouseNumberIndicator = a.HouseNumberIndicator
            };
        }

        public ContactInfoDto MapContactInfoToDto(ContactInfo c)
        {
            return new ContactInfoDto()
            {
                Name = c.Name,
                CommercialName = c.CommercialName,
                Address = MapAddressToDto(c.Address),
                Email = c.Email
            };
        }

        public CustomerDto MapCustomerToDto(Customer c)
        {
            return new CustomerDto()
            {
                ContactInfo = MapContactInfoToDto(c.ContactInfo),
                IsBusiness = c.IsBusiness,
                VatNumber = c.VatNumber,
            };
        }

        public BusinessDto MapBusinessToDto(Domain.Entities.Business b)
        {
            return new BusinessDto()
            {
                ContactInfo = MapContactInfoToDto(b.ContactInfo),
                VatNumber = b.VatNumber
            };
        }

        public WorkItemDto MapWorkItemToDto(WorkItem w)
        {
            return new WorkItemDto()
            {
                StartTime = w.StartTime,
                EndTime = w.EndTime,
                Location = MapAddressToDto(w.Location),
                Rate = w.Rate,
                Description = w.Description,
                Note = w.Note,
                VatCode = w.VatCode
            };
        }
    }
}
