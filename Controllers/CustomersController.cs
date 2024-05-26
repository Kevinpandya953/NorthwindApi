using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly northwindContext _context;

        public CustomersController(northwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers(int pageNo = 1, int pageSize = 10)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            if (pageNo <= 0)
            {
                pageNo = 1;
            }
            if (pageSize < +0)
            {
                pageSize = 10;
            }
            var customers = await _context.Customers
                                          .Skip((pageNo - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
            return Ok(customers);}

        [HttpGet("GetCustomersByCountry")]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomersByCountry(string Country)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var Customers = await _context.Customers
                                            .Where(c => c.Country == Country)
                                            .ToListAsync();

            if (Customers == null || !Customers.Any())
            {
                return NotFound();
            }
            return Ok(Customers);
        }
    }
}