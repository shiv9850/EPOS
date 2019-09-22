using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_POS.DBContext;
using E_POS.Models;

namespace E_POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly PosContext _context;

        public InvoiceController(PosContext context)
        {
            _context = context;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
            return await _context.Invoice.ToListAsync();
        }

        // GET: api/Invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoice.Where(item=>item.Id==id)
                .Include(item=>item.InvoiceDetails)
                .ThenInclude(item=>item.Item)
                .FirstOrDefaultAsync();

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoice/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Invoice
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
