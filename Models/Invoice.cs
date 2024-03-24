using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Models
{
    public class Invoice
    {
        public int ID { get; set; }        

        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        //[DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalValue { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
