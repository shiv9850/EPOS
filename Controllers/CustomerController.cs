using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_POS.DBContext;
using E_POS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_POS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly PosContext context;

        public CustomerController(PosContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [ActionName("getCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            //using (var context = new PosContext())
            //{
                return await context.Customers.ToListAsync();
        //    }
        }

        [HttpGet("{id}")]
        [ActionName("getCustomers")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
          //  using (var context = new PosContext<>())
            {
                var customer = await context.Customers.Where(item => item.Id == id)
                   // .Include(item => item.Contact)
                    //.Include(item => item.Addresses)
                    .FirstOrDefaultAsync();
                if (customer == null)
                {
                    return NotFound();
                }

                return customer;
            }
        }

        [HttpPost]
        [ActionName("addCustomer")]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
            //    using (var context = new PosContext())
                {
                    var addedCustomer = await context.Customers.AddAsync(customer);
                    await context.SaveChangesAsync();
                    return addedCustomer.Entity;
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [ActionName("updateCustomer")]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
              //  using (var context = new PosContext())
                {
                    context.Attach<Customer>(customer).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return NoContent();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [ActionName("deleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            //using (var context = new PosContext())
            {
                var customerToDelete = await context.Customers.FindAsync(id);
                if (customerToDelete != null)
                {
                    context.Customers.Remove(customerToDelete);
                    await context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
        }
    }
}
