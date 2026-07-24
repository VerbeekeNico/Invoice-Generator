namespace Invoicing.Domain.ValueObjects
{
    public class ContactInfo
    {
        public required string Name { get; set; }
        public string CommercialName { get; set; } = string.Empty;
        public required Address Address { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}