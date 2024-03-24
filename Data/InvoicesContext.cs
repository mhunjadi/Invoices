using Invoices.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Invoices.Data
{
    public class InvoicesContext : DbContext
    {
        public InvoicesContext(DbContextOptions<InvoicesContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(i => i.Invoices)
                .WithOne(c => c.Customer)
                .HasForeignKey(i => i.CustomerID);
        }
    }
}
