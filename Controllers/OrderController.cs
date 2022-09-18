using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Models;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public OrderController(RestaurantDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetOrderMasters() {
            return await _context.OrderMasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMaster>> GetOrderMaster(long id) {
            var orderMaster = await _context.OrderMasters.FindAsync(id);

            if (orderMaster == null)
            {
                return NotFound();
            }

            return orderMaster;
        }

        [HttpPost]
        public async Task<ActionResult<OrderMaster>> PostOrderMaster(OrderMaster OrderMaster) {
            _context.OrderMasters.Add(OrderMaster);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrderMaster", new { id = OrderMaster.OrderMasterId}, OrderMaster);
        }

       


    }
}