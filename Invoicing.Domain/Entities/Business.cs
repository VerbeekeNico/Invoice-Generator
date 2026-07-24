using Invoicing.Domain.ValueObjects;

namespace Invoicing.Domain.Entities
{
    public class Business
    {
        public required ContactInfo ContactInfo { get; set;  }
        public required string VatNumber { get; set; }
    }
}