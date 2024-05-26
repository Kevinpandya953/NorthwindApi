using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsExtendedController : ControllerBase
    {
        private readonly northwindContext _context;

        public OrderDetailsExtendedController(northwindContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailsExtended>>> GetOrderDetailsExtended()
        {
            if(_context.OrderDetailsExtended == null)
            {
                return NotFound();  
            }

            var orderDetailsExtended = await _context.OrderDetailsExtended.ToListAsync();

            return Ok(orderDetailsExtended);
        }
        
    }
}

