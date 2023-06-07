using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}