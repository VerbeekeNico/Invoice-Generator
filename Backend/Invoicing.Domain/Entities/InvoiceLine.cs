using Invoicing.Domain.Enums;

namespace Invoicing.Domain.Entities
{
    public class InvoiceLine : Invoicing.Domain.IEntity
    {
        public int Id { get; set; }

        public required VatCode VatCode { get; set; }
        public required string Description {  get; set; }

        public required int InvoiceId { get; set; }
        public required Invoicing.Domain.Entities.Invoice Invoice { get; set; }

        public ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
    }
}
