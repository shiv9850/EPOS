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
    public class ItemCatalogController : ControllerBase
    {
        private readonly PosContext _context;

        public ItemCatalogController(PosContext context)
        {
            _context = context;
        }

        // GET: api/ItemCatalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCatalog>>> GetItemCatalog()
        {
            return await _context.ItemCatalog.ToListAsync();
        }

        // GET: api/ItemCatalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCatalog>> GetItemCatalog(int id)
        {
            var itemCatalog = await _context.ItemCatalog.FindAsync(id);

            if (itemCatalog == null)
            {
                return NotFound();
            }

            return itemCatalog;
        }

        // PUT: api/ItemCatalog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCatalog(int id, ItemCatalog itemCatalog)
        {
            if (id != itemCatalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCatalogExists(id))
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

        // POST: api/ItemCatalog
        [HttpPost]
        public async Task<ActionResult<ItemCatalog>> PostItemCatalog(ItemCatalog itemCatalog)
        {
            _context.ItemCatalog.Add(itemCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCatalog", new { id = itemCatalog.Id }, itemCatalog);
        }

        // DELETE: api/ItemCatalog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCatalog>> DeleteItemCatalog(int id)
        {
            var itemCatalog = await _context.ItemCatalog.FindAsync(id);
            if (itemCatalog == null)
            {
                return NotFound();
            }

            _context.ItemCatalog.Remove(itemCatalog);
            await _context.SaveChangesAsync();

            return itemCatalog;
        }

        private bool ItemCatalogExists(int id)
        {
            return _context.ItemCatalog.Any(e => e.Id == id);
        }
    }
}
