namespace Invoicing.Contract.Dtos
{
    public class BusinessDto
    {
        public required ContactInfoDto ContactInfo { get; set; }
        public required string VatNumber { get; set; }
    }
}
