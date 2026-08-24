using Microsoft.EntityFrameworkCore;
using Invoicing.Domain.Entities;

namespace Invoicing.Infrastructure
{
    public class InvoicingDbContext : DbContext
    {
        public InvoicingDbContext(DbContextOptions<InvoicingDbContext> options) : base(options)
        {
        }

        public DbSet<Invoicing.Domain.Entities.Business> Businesses { get; set; } = null!;
        public DbSet<Invoicing.Domain.Entities.Customer> Customers { get; set; } = null!;
        public DbSet<Invoicing.Domain.Entities.Invoice> Invoices { get; set; } = null!;
        public DbSet<Invoicing.Domain.Entities.InvoiceLine> InvoiceLines { get; set; } = null!;
        public DbSet<Invoicing.Domain.Entities.WorkItem> WorkItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure owned/value objects
            modelBuilder.Entity<Invoicing.Domain.Entities.Customer>(b =>
            {
                b.ComplexProperty(c => c.ContactInfo, ci =>
                {
                    ci.ComplexProperty(c => c.Address);
                });
            });

            modelBuilder.Entity<Invoicing.Domain.Entities.Business>(b =>
            {
                b.ComplexProperty(bu => bu.ContactInfo, ci =>
                {
                    ci.ComplexProperty(c => c.Address);
                });
            });

            // Relationships
            modelBuilder.Entity<Invoicing.Domain.Entities.Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoicing.Domain.Entities.Invoice>()
                .HasOne(i => i.Seller)
                .WithMany()
                .HasForeignKey(i => i.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoicing.Domain.Entities.InvoiceLine>()
                .HasOne(il => il.Invoice)
                .WithMany(i => i.InvoiceLines)
                .HasForeignKey(il => il.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Invoicing.Domain.Entities.WorkItem>()
                .HasOne(w => w.InvoiceLine)
                .WithMany(il => il.WorkItems)
                .HasForeignKey(w => w.InvoiceLineId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Invoicing.Domain.Entities.WorkItem>()
                .ComplexProperty(w => w.Location);

            modelBuilder.Entity<WorkItem>()
                .Property(w => w.Rate)
                .HasPrecision(18, 2);

            // InvoiceLineId is optional on WorkItem (nullable FK)
            modelBuilder.Entity<Invoicing.Domain.Entities.WorkItem>()
                .Property<int?>(w => w.InvoiceLineId)
                .IsRequired(false);
        }
    }
}
