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

            Random random = new Random();
            var invoices = new Invoice[100];
            var customers = new List<Customer>();
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-14);
            endDate = endDate.AddDays(4);
            TimeSpan timeSpan = endDate - startDate;

            for (var i = 0; i < invoices.Length; i++)
            {
                TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newDate = startDate + newSpan;
                Invoice invoice = new Invoice();
                invoice.CustomerID = i % 10 == 0 ? random.Next(1000, 5000) : invoices[i - 1].CustomerID;
                invoice.InvoiceDate = newDate;
                invoice.TotalValue = (decimal)(random.NextSingle() * 1000);
                invoices[i] = invoice;
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
