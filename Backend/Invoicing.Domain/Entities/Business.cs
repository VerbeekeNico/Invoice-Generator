using Invoicing.Domain.ValueObjects;
using Invoicing.Domain;

namespace Invoicing.Domain.Entities
{
    public class Business : IEntity
    {
        public int Id { get; set; }

        public required ContactInfo ContactInfo { get; set;  }
        public required string VatNumber { get; set; }
    }
}
