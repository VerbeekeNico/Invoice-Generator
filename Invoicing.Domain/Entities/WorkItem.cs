using Invoicing.Domain.Enums;
using Invoicing.Domain.ValueObjects;

namespace Invoicing.Domain.Entities
{
    public class WorkItem
    {
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required Address Location { get; set; }
        public required Decimal Rate { get; set; }
        public required string Description { get; set; }
        public string Note { get; set; } = string.Empty;
        public VatCode VatCode { get; set; } = VatCode.Standard21;
    }
}