namespace Invoicing.Domain.Entities
{
    public class Invoice
    {
        public required Business Seller { get; set; }
        public required Customer Customer { get; set; }
        public required string InvoiceNumber { get; set; }
        public required DateTime InvoiceDate { get; set; }
        public required DateTime InvoiceDueDate { get; set; }

        public required IEnumerable<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
    }
}