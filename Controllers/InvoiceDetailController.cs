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
    public class InvoiceDetailController : ControllerBase
    {
        private readonly PosContext _context;

        public InvoiceDetailController(PosContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetails>>> GetInvoiceDetails()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        // GET: api/InvoiceDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetails>> GetInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);

            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return invoiceDetails;
        }

        // PUT: api/InvoiceDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceDetails(int id, InvoiceDetails invoiceDetails)
        {
            if (id != invoiceDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailsExists(id))
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

        // POST: api/InvoiceDetail
        [HttpPost]
        public async Task<ActionResult<InvoiceDetails>> PostInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Add(invoiceDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceDetails", new { id = invoiceDetails.Id }, invoiceDetails);
        }

        // DELETE: api/InvoiceDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceDetails>> DeleteInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            _context.InvoiceDetails.Remove(invoiceDetails);
            await _context.SaveChangesAsync();

            return invoiceDetails;
        }

        private bool InvoiceDetailsExists(int id)
        {
            return _context.InvoiceDetails.Any(e => e.Id == id);
        }
    }
}
