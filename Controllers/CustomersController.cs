using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Invoices.Data;
using Invoices.Models;

namespace Invoices.Controllers
{
    public class CustomersController : Controller
    {
        private readonly InvoicesContext _context;

        public CustomersController(InvoicesContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(int? id)
        {
            if (id == 1)
            {
                var customers = await _context.Customers
                  .Include(i => i.Invoices.Where(inv => inv.InvoiceDate >= DateTime.Today.AddDays(-7) && inv.InvoiceDate < DateTime.Today))
                  .ToListAsync();

                return View(customers);
            }
            else if (id == 2)
            {
                var customers = await _context.Customers
                 .Include(i => i.Invoices.Where(inv => inv.InvoiceDate >= DateTime.Today.AddDays(-14) && inv.InvoiceDate < DateTime.Today.AddDays(-7)))
                 .ToListAsync();

                return View(customers);
            }
            else
            {
                var customers = await _context.Customers
                  .Include(i => i.Invoices)
                  .ToListAsync();

                return View(customers);
            }

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
    }
}
