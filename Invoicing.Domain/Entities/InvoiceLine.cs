using Invoicing.Domain.Enums;

namespace Invoicing.Domain.Entities
{
    public class InvoiceLine
    {
        public required VatCode VatCode { get; set; }
        public required string Description {  get; set; }
        public required IEnumerable<WorkItem> WorkItems { get; set; }
    }
}
