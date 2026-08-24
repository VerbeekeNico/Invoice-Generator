using Invoicing.Domain.ValueObjects;
using Invoicing.Domain;

namespace Invoicing.Domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public required ContactInfo ContactInfo{ get; set; }
        public bool IsBusiness { get; set; }
        public string? VatNumber { get; set;  }

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
