using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Models
{
    public class OrderMaster
    {
        [Key]
        public int OrderMasterId { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PMethod { get; set; }

        public decimal GTotal { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        [NotMapped]
        public String DeletedOrderItemIds { get; set; }
    }
}