using Invoices.Models;

namespace Invoices.Data
{
    public class DbInitializer
    {
        public static void Initialize(InvoicesContext context)
        {
            // Look for any invoices.
            if (context.Invoices.Any())
            {
                return;   // DB has been seeded
            }

            Random random = new();
            var invoices = new List<Invoice>();
            var customers = new List<Customer>();
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-14);
            endDate = endDate.AddDays(4);
            TimeSpan timeSpan = endDate - startDate;

            for (var i = 0; i < 100; i++)
            {
                TimeSpan newSpan = new(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newDate = startDate + newSpan;
                Invoice invoice = new()
                {
                    CustomerID = i % 10 == 0 ? random.Next(1000, 5000) : invoices[i - 1].CustomerID,
                    InvoiceDate = newDate,
                    TotalValue = (decimal)(random.NextSingle() * 1000)
                };
                invoices.Add(invoice);
                if(customers.FindIndex(x => x.ID == invoice.CustomerID) == -1)
                    customers.Add(new Customer() { ID = invoice.CustomerID, Name = "KUPAC " + invoice.CustomerID });
            }
            
            context.Customers.AddRange(customers);
            context.SaveChanges();

            context.Invoices.AddRange(invoices);
            context.SaveChanges();
        }
    }
}
