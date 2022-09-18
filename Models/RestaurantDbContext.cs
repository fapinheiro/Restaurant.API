using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.API.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        public DbSet<OrderMaster> OrderMasters { get; set; }
    }
}