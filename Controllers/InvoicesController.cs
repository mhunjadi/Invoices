using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Invoices.Data;

namespace Invoices.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoicesContext _context;

        public InvoicesController(InvoicesContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var invoices = await _context.Invoices.ToListAsync();
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }
    }
}
