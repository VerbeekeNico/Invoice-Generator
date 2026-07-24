namespace Invoicing.Contract.Dtos
{
    public class CustomerDto
    {
        public required ContactInfoDto ContactInfo { get; set; }
        public bool IsBusiness { get; set; }
        public string? VatNumber { get; set; }
    }
}