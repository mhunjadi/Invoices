using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Invoices.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string? Name { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
