using Invoicing.Business.Interfaces;
using Invoicing.Domain.Entities;
using Invoicing.Domain.Enums;
using Invoicing.Domain.ValueObjects;

namespace Invoicing.Infrastructure
{
    // one repository to provide all demodata at the moment
    public class DemoRepository : IDemoRepository
    {
        private Domain.Entities.Business MyBusiness;
        private Customer FirstCustomer;
        private Customer SecondCustomer;
        private List<WorkItem> WorkItems = new List<WorkItem>();

        public List<Invoice> Invoices = new List<Invoice>();

        public DemoRepository()
        {
            MyBusiness = new Domain.Entities.Business()
            {
                ContactInfo = new ContactInfo()
                {
                    Address = new Address()
                    {
                        City = "Oostkamp",
                        Street = "Straat in Oostkamp",
                        HouseNumberIndicator = "10",
                        PostalCode = "8020"
                    },
                    Name = "Nico Verbeeke",
                    CommercialName = "IncogNico Systems",
                    Email = ""
                },
                VatNumber = "BE1234.123.123"
            };

            FirstCustomer = new Customer()
            {
                ContactInfo = new ContactInfo()
                {
                    Address = new Address()
                    {
                        City = "Beernem",
                        Street = "Beernemstraat",
                        HouseNumberIndicator = "10",
                        PostalCode = "8730"
                    },
                    Name = "Jan Jansens",
                    Email = "JanJansens@example.com"
                },
                VatNumber = "BE4567.234.234"
            };

            SecondCustomer = new Customer()
            {
                ContactInfo = new ContactInfo()
                {
                    Address = new Address()
                    {
                        City = "Brugge",
                        Street = "Stationslaan",
                        HouseNumberIndicator = "42B",
                        PostalCode = "8000"
                    },
                    Name = "Sophie Vermeulen",
                    Email = "sophie.vermeulen@example.com"
                },
                VatNumber = "BE0789.456.123"
            };

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow.AddDays(-5),
                EndTime = DateTime.UtcNow.AddDays(-5).AddHours(8),
                Location = FirstCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "Technical work",
                Note = "",
                VatCode = VatCode.Standard21
            });

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow.AddDays(-4),
                EndTime = DateTime.UtcNow.AddDays(-4).AddHours(8),
                Location = SecondCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "Lighting maintenance",
                Note = "",
                VatCode = VatCode.Standard21
            });

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow.AddDays(-3),
                EndTime = DateTime.UtcNow.AddDays(-3).AddHours(8),
                Location = FirstCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "Network cabling",
                Note = "",
                VatCode = VatCode.Standard21
            });

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow.AddDays(-2),
                EndTime = DateTime.UtcNow.AddDays(-2).AddHours(8),
                Location = SecondCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "Inspection and testing",
                Note = "",
                VatCode = VatCode.Standard21
            });

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow.AddDays(-1),
                EndTime = DateTime.UtcNow.AddDays(-1).AddHours(8),
                Location = FirstCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "Panel wiring",
                Note = "",
                VatCode = VatCode.Standard21
            });

            WorkItems.Add(new WorkItem()
            {
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(8),
                Location = SecondCustomer.ContactInfo.Address,
                Rate = 500 / 8m,
                Description = "General electrical works",
                Note = "",
                VatCode = VatCode.Standard21
            });
        }

        public Domain.Entities.Business GetMyBusiness()
        {
            return MyBusiness;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>() { FirstCustomer, SecondCustomer };
        }

        public IEnumerable<WorkItem> GetWorkItems()
        {
            return WorkItems;
        }
    }
}
