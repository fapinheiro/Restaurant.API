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
            return await _context.OrderMasters.Include(x => x.Customer).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMaster>> GetOrderMaster(int id) {

            // var orderMaster = await _context.OrderMasters.FindAsync(id);
            var orderDetails = await (from master in _context.Set<OrderMaster>()
                                     join detail in _context.Set<OrderDetail>()
                                     on master.OrderMasterId equals detail.OrderMasterId
                                     join foodItem in _context.Set<FoodItem>()
                                     on detail.FoodItemId equals foodItem.FoodItemId
                                     where master.OrderMasterId == id
                                     
                                     select new
                                     {
                                        master.OrderMasterId,
                                        detail.OrderDetailId,
                                        detail.FoodItemId,
                                        detail.Quantity,
                                        detail.FoodItemPrice,
                                        foodItem.FoodItemName
                                     }).ToListAsync();

            var orderMaster = await (from a in  _context.Set<OrderMaster>()
                                     where a.OrderMasterId == id
                                     
                                     select new 
                                     {
                                        a.OrderMasterId,
                                        a.OrderNumber,
                                        a.CustomerId,
                                        a.PMethod,
                                        a.GTotal,
                                        deletedOrderItemIds="",
                                        orderDetails=orderDetails
                                     }).FirstOrDefaultAsync();

            if (orderMaster == null)
            {
                return NotFound();
            }

            return Ok(orderMaster);
        }

        [HttpPost]
        public async Task<ActionResult<OrderMaster>> PostOrderMaster(OrderMaster OrderMaster) {
            _context.OrderMasters.Add(OrderMaster);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrderMaster", new { id = OrderMaster.OrderMasterId}, OrderMaster);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderMaster(int id) {
            var orderMaster = await _context.OrderMasters.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            _context.OrderMasters.Remove(orderMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMaster(int id, OrderMaster orderMaster) {
            if (id != orderMaster.OrderMasterId) {
                return BadRequest();
            }

            _context.Entry(orderMaster).State = EntityState.Modified;

            foreach (OrderDetail item in orderMaster.OrderDetails) {
                if (item.OrderDetailId==0) {
                    _context.OrderDetails.Add(item);
                }
                else {
                    _context.Entry(item).State = EntityState.Modified;
                }
            }

            foreach(var i in orderMaster.DeletedOrderItemIds.Split(',').Where(x => x != ""))
            {
                OrderDetail y = _context.OrderDetails.Find(Convert.ToInt32(i));
                _context.OrderDetails.Remove(y);
            }

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMasterExists(id)) {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }
            return NoContent();
        }

        public bool OrderMasterExists(int id) {
            var orderMaster = _context.OrderMasters.Find(id);
            return orderMaster != null;
        }
    }
}