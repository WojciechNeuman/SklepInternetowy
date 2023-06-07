using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}