using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public FoodItemController(RestaurantDbContext context) {
            _context = context;
        }   

         [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems() {
            return await _context.FoodItems.ToListAsync();
        }
    }
}