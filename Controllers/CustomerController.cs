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
    public class CustomerController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public CustomerController(RestaurantDbContext context) {
            _context = context;
        }   

         [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers() {
            return await _context.Customers.ToListAsync();
        }
    }
}