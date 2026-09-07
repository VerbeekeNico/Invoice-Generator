namespace Invoicing.Domain.Entities
{
    public class Invoice : Invoicing.Domain.IEntity
    {
        public int Id { get; set; }

        public required Invoicing.Domain.Entities.Business Seller { get; set; }
        public int SellerId { get; set; }

        public required Invoicing.Domain.Entities.Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public required string InvoiceNumber { get; set; }
        public required DateTime InvoiceDate { get; set; }
        public required DateTime InvoiceDueDate { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
    }
}