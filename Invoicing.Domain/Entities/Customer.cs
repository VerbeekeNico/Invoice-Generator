using Invoicing.Domain.ValueObjects;

namespace Invoicing.Domain.Entities
{
    public class Customer
    {
        public required ContactInfo ContactInfo{ get; set; }
        public bool IsBusiness { get; set; }
        public string? VatNumber { get; set;  }
    }
}