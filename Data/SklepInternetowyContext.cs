using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SklepInternetowy;

namespace SklepInternetowy.Data
{
    public class SklepInternetowyContext : DbContext
    {
        public SklepInternetowyContext (DbContextOptions<SklepInternetowyContext> options)
            : base(options)
        {
        }

        public DbSet<SklepInternetowy.Customer> Customer { get; set; } = default!;
        
        public DbSet<SklepInternetowy.Order> Order { get; set; } = default!;

        public DbSet<SklepInternetowy.OrderItem> OrderItem { get; set; } = default!;

        public DbSet<SklepInternetowy.Product> Product { get; set; } = default!;
    }
}
