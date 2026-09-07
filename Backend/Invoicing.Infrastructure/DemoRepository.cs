using Invoicing.Business.Interfaces;
using Invoicing.Contract;
using Invoicing.Domain.Entities;
using Invoicing.Domain.Enums;
using Invoicing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Infrastructure
{
    // one repository to provide all demodata at the moment
    public class DemoRepository : IDemoRepository, IWorkItemRepository
    {
        private Domain.Entities.Business MyBusiness;
        private Customer FirstCustomer;
        private Customer SecondCustomer;
        private List<WorkItem> WorkItems = new List<WorkItem>();
        private readonly InvoicingDbContext _dbContext;

        public List<Invoice> Invoices = new List<Invoice>();

        public DemoRepository(InvoicingDbContext dbContext)
        {
            _dbContext = dbContext;
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

        // IWorkItemRepository implementation
        public async Task<WorkItem?> GetByIdAsync(int id)
        {
            return await _dbContext.WorkItems.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WorkItem>> GetAllAsync()
        {
            return await _dbContext.WorkItems.ToListAsync();
        }

        public async Task<WorkItem> CreateAsync(WorkItem workItem)
        {
            _dbContext.WorkItems.Add(workItem);
            await _dbContext.SaveChangesAsync();
            return workItem;
        }

        public async Task<WorkItem> UpdateAsync(WorkItem workItem)
        {
            _dbContext.WorkItems.Update(workItem);
            await _dbContext.SaveChangesAsync();
            return workItem;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var workItem = await GetByIdAsync(id);
            if (workItem == null)
            {
                return false;
            }

            // Only allow deletion if not assigned to an invoice line
            if (workItem.InvoiceLineId.HasValue)
            {
                throw new InvalidOperationException("Cannot delete a work item that is assigned to an invoice line.");
            }

            _dbContext.WorkItems.Remove(workItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
