namespace Invoicing.Contract.Dtos
{
    public class ContactInfoDto
    {
        public required string Name { get; set; }
        public string CommercialName { get; set; } = string.Empty;
        public required AddressDto Address { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
