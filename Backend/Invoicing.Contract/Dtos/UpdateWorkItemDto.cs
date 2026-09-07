using Invoicing.Domain.Enums;

namespace Invoicing.Contract.Dtos
{
    public class UpdateWorkItemDto
    {
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required AddressDto Location { get; set; }
        public required Decimal Rate { get; set; }
        public required string Description { get; set; }
        public string Note { get; set; } = string.Empty;
        public VatCode VatCode { get; set; } = VatCode.Standard21;
    }
}
